    using System;
    using System.Text;
    
    class Test
    {
        static void Main()
        {
            byte[] bytes = { 0x41, 0xd, 0xa, 0x42 };
            string text = Encoding.UTF8.GetString(bytes);
            Console.WriteLine(text == "A\r\nB");
        }
    }
