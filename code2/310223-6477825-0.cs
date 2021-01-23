    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                String textFromFile = "some text [re\r\npla\r\nme] more [Anoth\r\ner\r\n place\r\n\r\n\r\n holder] text";
    
                foreach (Match match in Regex.Matches(textFromFile, "\\[([^\\]]+)\\]"))
                {
                    String placeHolder = match.Groups[1].Value.Replace("\r\n", "");
                    // *** Do rest of your work here ***.
                    System.Console.WriteLine(placeHolder);
                }
            }
        }
    }
