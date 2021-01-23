    class Program
        {
            static void Main(string[] args)
            {
                ReadPhone();
                Console.ReadLine();
            }
    
            private static void ReadPhone()
            {
                var numericPhoneNumber = string.Empty;
    
                Console.Write("Please enter your phone number: ");
                do
                {
                    var keyInfo= Console.ReadKey();
                    if (char.IsDigit(keyInfo.KeyChar))
                    {
                        numericPhoneNumber += keyInfo.KeyChar;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please enter numeric numbers only");
                    }
                }
                while (numericPhoneNumber.Length <= 10);
                Console.WriteLine("Phone Number: {0}", numericPhoneNumber);
            }
        }
