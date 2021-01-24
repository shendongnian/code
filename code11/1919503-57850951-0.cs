    public class DoMath
    {
       public static string Pi { get; private set; } = "3.14";
       public static double X {get; set;}
       public static double Y {get; set;}
    
       public static double Sum() => X + Y;
    }
    
    DoMath.X = 3.5;
    DoMath.Y = 4;
    double result = DoMath.Sum();
    Console.WriteLine($"Pi is equal to {DoMath.Pi}.");
