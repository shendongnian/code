    using System;
    
    class Test
    {
        static void Main()
        {
            DateTimeOffset dto = new DateTimeOffset(2009, 7, 20,
                                                    0, 0, 0, TimeSpan.Zero);
            string text = dto.ToString("dd. MMMM yyyy.");
            Console.WriteLine(text); // Prints 20. July 2009. on my machine
        }
    }
