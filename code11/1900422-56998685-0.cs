    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                //15:32:14.186 [http-nio-18080-exec-5] DEBUG org.springframework.web.servlet.mvc.method.annotation.RequestMappingHandlerMapping
                string pattern = @"(?'time'[\d:.]+)\s+\[(?'http'[^]]+)\]\s+DEBUG\s+(?'message'.*)";
                StreamReader reader = new StreamReader(FILENAME);
                string line = "";
                while((line = reader.ReadLine()) != null)
                {
                    Match match = Regex.Match(line, pattern);
                    if (match.Success)
                    {
                        Console.WriteLine(match.Groups["message"].Value);
                    }
                }
                Console.ReadLine();
            }
        }
    }
