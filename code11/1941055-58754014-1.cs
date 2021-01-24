cs
public class Function<TReturn> {
	private readonly object[] _argv;
	private readonly Delegate _func;
	public Function(Delegate func, params object[] args) {
		_func = func;
		_argv = args;
	}
	public TReturn Run() {
		object v = _func.DynamicInvoke(_argv);
		return (TReturn)v;
	}
}
And its usage lets you decide dynamically the number of arguments you wish to pass:
cs
var s = new Function<double>((Func<double, double>)(x => Math.Sin(x)), 1 );
Console.WriteLine(s.Run()); // prints 0.8414709848078965
var p = new Function<double>((Func<double, double, double>)((a, b) => Math.Pow(a, b)), 2, 3);
Console.WriteLine(p.Run()); // prints 8
var d = new Function<string>((Func<string, double, string>)((a, b) => a + b.ToString()), "hello, ", 42);
Console.WriteLine(p.Run()); // prints "hello, 42"
Note that type checking is only performed at run-time when calling `Function.Run()` and not when constructing the `Function` object because of its dynamic nature. If you know for sure that all passed arguments will always be of the same type, you could enforce that statically by adding a `TArg` generic type.
