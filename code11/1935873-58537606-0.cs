    public class Program
    {
    public static void Main()
    {
        int i  = 0;
        int rep = int.Parse(Console.ReadLine());
        int hi = int.Parse(Console.ReadLine());
        int big = 0;
        for( i = 0; i < rep; i++)
        {
            if(hi > big)
            {
                big = hi;
                Console.WriteLine(big);
            }
        }
        
    }
    }
