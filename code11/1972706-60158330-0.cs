try
{
    int zero = 0;
    int i = 1/zero;
}
catch (DividedByZeroException ex)
{
    Console.WriteLine(Exception handled);
    throw; // propagate ex to caller
}
finally
{
    Console.WriteLine("Method ended execution"); // called with or without exception
}
