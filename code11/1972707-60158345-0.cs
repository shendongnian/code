    using System;
    public sealed class Program
    {
    public static void Main()
    {
        try
        {
            int zero = 0;
            int i = 1 / zero;
        }
        catch
        {
        }
        finally
        {
            Console.WriteLine("divide by zero"); //the line is never called
        }
    }
    }
