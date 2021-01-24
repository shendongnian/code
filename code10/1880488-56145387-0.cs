    using System;
    
    class Sample 
    {
        public static void Main() 
        {
        string m1 = "\nType a string of text then press Enter. " +
                    "Type '+' anywhere in the text to quit:\n";
        string m2 = "Character '{0}' is hexadecimal 0x{1:x4}.";
        string m3 = "Character     is hexadecimal 0x{0:x4}.";
        char ch;
        int x;
    //
        Console.WriteLine(m1);
        do  
            {
            x = Console.Read();
            try 
                {
                ch = Convert.ToChar(x);
                if (Char.IsWhiteSpace(ch))
                   {
                   Console.WriteLine(m3, x);
                   if (ch == 0x0a) 
                       Console.WriteLine(m1);
                   }
                else
                   Console.WriteLine(m2, ch, x);
                }
            catch (OverflowException e) 
                {
                Console.WriteLine("{0} Value read = {1}.", e.Message, x);
                ch = Char.MinValue;
                Console.WriteLine(m1);
                }
            } while (ch != '+');
        }
    }
