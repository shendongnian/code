    using System;
    
    class Program {
        static void Main(string[] args) {
            var ex = new System.ComponentModel.Win32Exception(unchecked((int)0x80004005));
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
    }
