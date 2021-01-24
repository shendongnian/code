    static async Task Main()
    {
        try
        {
            Console.WriteLine("Before calling "+ nameof(AsyncMathsStatic.Divide1));
            var t = AsyncMathsStatic.Divide1(4, 0);
            Console.WriteLine("After calling "+ nameof(AsyncMathsStatic.Divide1));
            await t;
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Exception thrown in " + nameof(Main));
        }
    
        try
        {
            Console.WriteLine("Before calling "+ nameof(AsyncMathsStatic.Divide2));
            var t = AsyncMathsStatic.Divide2(4, 0);
            Console.WriteLine("After calling "+ nameof(AsyncMathsStatic.Divide2));
            await t;
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Exception thrown in " + nameof(Main));
        }
    }
    
    public class AsyncMathsStatic
    {
        public static async Task Divide1(int v1, int v2)
        {
            try
            {
                Console.WriteLine(nameof(Divide1) + ".1");
                await Task.Yield();
                Console.WriteLine(nameof(Divide1) + ".2");
                if (v1 / v2 > 1)
                {
                    await Task.Yield();
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Exception thrown in " + nameof(Divide1));
                throw;
            }
        }
        public static async Task Divide2(int v1, int v2)
        {
            try
            {
                Console.WriteLine(nameof(Divide2) + ".1");
                await Task.CompletedTask;
                Console.WriteLine(nameof(Divide2) + ".2");
                if (v1 / v2 > 1)
                {
                    await Task.Yield();
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Exception thrown in " + nameof(Divide2));
                throw;
            }
        }
    }
    /* Output
    Before calling Divide1
    Divide1.1
    After calling Divide1
    Divide1.2
    Exception thrown in Divide1
    Exception thrown in Main
    Before calling Divide2
    Divide2.1
    Divide2.2
    Exception thrown in Divide2
    After calling Divide2
    Exception thrown in Main
    */
