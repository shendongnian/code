    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    class PasswordGenerator
    {
        static void Main()
        {
            bool bypass = false;
            int length = 0;
    
            do
            {
                var passwordBuilder = new StringBuilder();
                Console.WriteLine("How many Characters would you like the Password to be? (Press '-1' to Stop)");
    
                /// try method is inside, replaced old try and catch
                var Input_is_Int = int.TryParse(Console.ReadLine(), out length);
    
                if (!Input_is_Int || length == 0)
                {
                    Console.WriteLine("That is an Invalid Number, Please try again");
                    Console.WriteLine();
                    bypass = false;
                }
                else if (Input_is_Int && length != -1)
                {
                    for (int i = 0; i < length; i++)
                        passwordBuilder.Append(GetRandomChar());
                    Console.WriteLine("Password: " + passwordBuilder.ToString());
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                    bypass = true;
                }
            }
            while (!bypass);
        }
    
        /// Union of ABCDEFGHIJKLMNOPQRSTUVWXYZ, 0123456789 and !"#$%&'()*+,-./ 
        static char[] _lookupTable = Enumerable.Range(65, 26).Union(Enumerable.Range(48, 10).Union(Enumerable.Range(33, 14))).Select(i => (char)i).ToArray();
    
        static Random _r = new Random();
    
        static char GetRandomChar()
        {
            var index = _r.Next(0, _lookupTable.Length);
            return _lookupTable[index];
        }
    }
