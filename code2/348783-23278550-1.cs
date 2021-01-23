    using System;
    using System.Text.RegularExpression;
    public namespace MyNS
    {
        public class MyClass
        {
            public void static Main(string[] args)
            {
                 string input = Console.ReadLine();
                 bool containsNumber = ContainsOnlyDigits(input);
            }
            private bool ContainOnlyDigits (string input)
            {
                bool containsNumbers = true;
                if (!Regex.IsMatch(input, @"/d"))
                {
                    containsNumbers = false;
                }
                return containsNumbers;
            }
        }
    }
