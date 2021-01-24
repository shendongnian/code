c#
var methodList = new List<Func<QCTraceSimulator, long, Task<QVoid>>>
{
    QuantumOperation.Run,
    // Add more methods here
}
This is a List of [Func](https://www.tutorialsteacher.com/csharp/csharp-func-delegate)s. A Func is a delegate type that represents a method with a parameter and a return value. Here our methods need to look like this to be able to be added to our List:
c#
public Task<QVoid> SomeName(QCTraceSimulator sim, long parameter)
{ ...}
We also need a list of parameters you want to try this with:
c#
var paramsList = new List<long>
{
    1,
    2,
   -2147483648,
    2147483647
};
Now we can iterate through these and run our method like so:
c#
public void RunMethodsOnSimulator(QCTraceSimulator sim)
{
    // Iterate through every method
    foreach (var method in methodList)
    {
        // Iterate through every parameter
        foreach (var parameter in paramsList)
        {
            // Execute the given method with the given parameter
            Task<QVoid> result = method(sim, parameter);
        }
    }
}
You can now do whatever you want with the `result`. This will result in every method being called with every parameter once
Please keep in mind that this answer only solves this problem for methods that return a `Task<QVoid>` and take a `QCTraceSimulator` and a `long` as parameter. This solution however avoids having to modify any `QuantumOperation` classes (and hopefully teaches you a little about delegates)
Here is what the `paramsList` and the `RunMethodsOnSimulator` method would like with 2 or more parameters:
c#
methodList = new List<Func<QCTraceSimulator, long, int, Task<QVoid>>>
{
    QuantumOperation.Run,
    // Add more methods here
}
paramsList = new List<Tuple<long, int>>
{
    new Tuple<long, int>(1, 1),
    new Tuple<long, int>(2, 1),
    new Tuple<long, int>(1, 2),
    new Tuple<long, int>(-2147483648, 1)
}
public void RunMethodsOnSimulator(QCTraceSimulator sim)
{
    // Iterate through every method
    foreach (var method in methodList)
    {
        // Iterate through every parameter
        foreach (var parameter in paramsList)
        {
            // Execute the given method with the given parameter
            Task<QVoid> result = method(sim, parameter.Item1, parameter.Item2);
        }
    }
}
