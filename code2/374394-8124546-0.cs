    using System;
    using System.Text;
    
    namespace Example
    {
        class Program
        {
            static void Main(string[] args)
            {
                string subjectString = @"green,""yellow,green"",white,orange,""blue,black""";
    
                bool inQuote = false;
                StringBuilder currentResult = new StringBuilder();
                foreach (char c in subjectString)
                {
                    switch (c)
                    {
                        case '\"':
                            inQuote = !inQuote;
                            break;
    
                        case ',':
                            if (inQuote)
                            {
                                currentResult.Append(c);
                            }
                            else
                            {
                                Console.WriteLine(currentResult);
                                currentResult.Clear();
                            }
                            break;
    
                        default:
                            currentResult.Append(c);
                            break;
                    }
                }
                if (inQuote)
                {
                    throw new FormatException("Input string does not have balanced Quote Characters");
                }
                Console.WriteLine(currentResult);
            }
        }
    }
