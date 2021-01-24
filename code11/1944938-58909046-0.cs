static int myStaticInt = 333;
public static int returnInt()
{
    return myStaticInt;
}
public static void callerMethod()
{
    var i = returnInt();
    i += 100;
    Console.WriteLine(i);
}
public async static Task Main(string[] args)
{
    Console.WriteLine(myStaticInt);
    callerMethod();
    Console.WriteLine(myStaticInt);
}
333
433
333
----
Here is a relevant part from [Passing Value-Type Parameters (C# Programming Guide)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/passing-value-type-parameters):
> A value-type variable contains its data directly as opposed to a reference-type variable, which contains a reference to its data. Passing a value-type variable to a method by value means passing a copy of the variable to the method. Any changes to the parameter that take place inside the method have no affect on the original data stored in the argument variable.
