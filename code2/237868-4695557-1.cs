    using System;
    using System.Text;
    
    class Test
    {    
        static void Main()
        {
            Encoding asciiClone = (Encoding) Encoding.ASCII.Clone();
            asciiClone.DecoderFallback = new DecoderReplacementFallback("%");
            asciiClone.EncoderFallback = new EncoderReplacementFallback("%");
                                                     
            byte[] bytes = { 65, 200, 66 };
            string text = asciiClone.GetString(bytes);
            Console.WriteLine(text); // Prints A%B
            bytes = asciiClone.GetBytes("A\u00ffB");
            Console.WriteLine(bytes[1]); // Prints 37
        }
    }
