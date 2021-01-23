    using System;
    using System.Text;
    
    class Test
    {    
        static void Main()
        {
            Encoding asciiClone = (Encoding) Encoding.ASCII.Clone();
            asciiClone.DecoderFallback = new DecoderReplacementFallback("%");
                                                     
            byte[] bytes = { 65, 200, 66 };
            string text = asciiClone.GetString(bytes);
            Console.WriteLine(text); // Prints A%B
        }
    }
