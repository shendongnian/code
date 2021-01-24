    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    
    namespace SampleNamespace
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var currentLine = string.Empty;
                var completeText = string.Empty;
                while(true)
                {
                    currentLine = Console.ReadLine();
                    if(currentLine.Trim().ToLower() == "q")
                        break;
                    else
                        completeText += currentLine + Environment.Newline;
                }
                
                File.WriteAllText(@"<FullpathForFile>", completeText);
            }
        }
    }
