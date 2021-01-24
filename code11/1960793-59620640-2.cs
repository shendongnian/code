csharp
public enum ExecutionResult
{
    RunToCompletion,
    Aborted
}
public interface IExecutable
{
    ExecutionResult Execute();
}
public interface IExecutable<T>
{
    ExecutionResult Execute(T argument);
}
We'll make two (technically three) implementations. First, a `SimpleExecutable` and `SimpleExecutable<T>`, that won't do any fancy stuff, just wrap an action and run it.
csharp
internal class SimpleExecutable : IExecutable
{
    private readonly Func<ExecutionResult> _action;
    public SimpleExecutable(Func<ExecutionResult> action) => _action = action;
    public ExecutionResult Execute() => _action();
}
internal class SimpleExecutable<T> : IExecutable<T>
{
    private readonly Func<T, ExecutionResult> _action;
    public SimpleExecutable(Func<T, ExecutionResult> action) => _action = action;
    public ExecutionResult Execute(T argument) => _action(argument);
}
Nothing interesting here, now the one you actually want, a `ShortCircuitingConditionalExecutable<T>`:
csharp
internal class ShortCircuitingConditionalExecutable<T> : IExecutable<T>
{
    private readonly Func<T, ExecutionResult> _action;
    private readonly Func<T, bool> _predicate;
    public ShortCircuitingConditionalExecutable(
        Func<T, ExecutionResult> action,
        Func<T, bool> predicate) =>
        (_action, _predicate) = (action, predicate);
    public ExecutionResult Execute(T argument)
    {
        if (!_predicate(argument))
        {
            return ExecutionResult.Aborted;
        }
        _action(argument);
        return ExecutionResult.RunToCompletion;
    }
}
`Execute` checks the predicate, runs the method if it's true and returns a result signalling whether we should short-circuit the operation.
To make this more handy to use, let's make a few helper extensions:
csharp
public static class Executable
{
    public static IExecutable<T> StartWithIf<T>(
        Action<T> action,
        Func<T, bool> predicate) =>
        new ShortCircuitingConditionalExecutable<T>(ReturnCompletion(action), predicate);
    public static IExecutable ContinueWith(this IExecutable source, IExecutable executable) =>
        new SimpleExecutable(ChainIfCompleted(source.Execute, executable.Execute));
    public static IExecutable<T> ContinueWith<T>(this IExecutable<T> source, IExecutable<T> executable) =>
        new SimpleExecutable<T>(ChainIfCompleted<T>(source.Execute, executable.Execute));
    public static IExecutable<T> ContinueWithIf<T>(
        this IExecutable<T> source,
        Action<T> action,
        Func<T, bool> predicate) =>
        source.ContinueWith(new ShortCircuitingConditionalExecutable<T>(ReturnCompletion(action), predicate));
    public static IExecutable BindArgument<T>(this IExecutable<T> source, T argument) =>
        new SimpleExecutable(() => source.Execute(argument));
    private static Func<ExecutionResult> ChainIfCompleted(
        Func<ExecutionResult> action1,
        Func<ExecutionResult> action2) =>
        () =>
        {
            var result = action1();
            return result != ExecutionResult.RunToCompletion ? result : action2();
        };
    private static Func<T, ExecutionResult> ChainIfCompleted<T>(
        Func<T, ExecutionResult> action1,
        Func<T, ExecutionResult> action2) =>
        t =>
        {
            var result = action1(t);
            if (result != ExecutionResult.RunToCompletion)
            {
                return result;
            }
            return action2(t);
        };
    private static Func<T, ExecutionResult> ReturnCompletion<T>(Action<T> action) =>
        t =>
        {
            action(t);
            return ExecutionResult.RunToCompletion;
        };
}
I've omitted a few obvious extensions we could make, but that's rather a lot of code, so maybe a motivating example of this thing in action:
csharp
class Program
{
    private static Func<int, bool> AreBitsSet(params int[] bits) => 
       n => bits.All(b => (n & (1 << b)) != 0);
    private static void Print(int n) => Console.WriteLine(n);
    static void Main(string[] args)
    {
        var num1 = (1 << 2) | (1 << 4) | (1 << 5);
        var num2 = num1 | (1 << 7);
        var executable = Executable.StartWithIf(Print, AreBitsSet(2))
            .ContinueWithIf(Print, AreBitsSet(2, 4, 5))
            .ContinueWithIf(Print, AreBitsSet(7));
        var executableNum1 = executable.BindArgument(num1);
        var executableNum2 = executable.BindArgument(num2);
        var program = executableNum1.ContinueWith(executableNum2);
        executable.Execute(num1);
        executable.Execute(num2);
        program.Execute();
    }
}
The first execution prints `52` twice (`num1`). The second execution prints `180` thrice (`num2`). The execution of `program` prints only `52` twice and short-circuits the rest of the execution.
This is not a fully production-ready module, as I've ignored argument validation and there are probably possible optimisations that would avoid some allocations when constructing the execution flow (we're making a lot of delegates). Also, it would be really nice to make this thing more fluent by enabling `execution.ContinueWith(action).If(predicate)` syntax. It's also terribly overcomplicated, since your use case requires only a very specific execution chain, but what the heck, it was fun writing it up.
Aside: To anyone interested, this is not a monad, but very close so. We would have to replace `Execute` with something that returns the constructed `Action<T>` delegate and then write up the appropriate `bind` function. Then we'd get a monad over `Action`s of any `T`, and we could still make `Execute` into an extension method that gets the delegate and immediately calls it. The `BindArgument` is a special case of a `bind`: `t => bind(e, f => () => f(t))`.
