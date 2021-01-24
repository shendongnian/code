    public class Program
    {
    	public static void Main()
    	{
    		decimal t = 1.0M;
    		Console.WriteLine(t.ToStringD(2));
    		Console.WriteLine(t.ToStringD());
    	}
    }
    
    public static class Extensions
    {
    	private const int DEFAULT_PRECISION = 4;
    	public static string ToStringD(this decimal value, int? precision = null)
            {
                return value.ToString("F" + (precision ?? DEFAULT_PRECISION).ToString());
            }
    }
