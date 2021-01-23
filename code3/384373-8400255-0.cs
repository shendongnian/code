    using System;
    using System.Globalization;
    
    class Sample {
        static void Main(){
            char c = 'あ';
            int unicode = c;
            string hex = string.Format("0x{0:x4}", unicode);
            Console.WriteLine(hex);
            unicode = int.Parse(hex.Substring(2), NumberStyles.HexNumber);
            c = (char)unicode;
            Console.WriteLine(c);
        }
    }
