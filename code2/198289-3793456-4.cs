    using System;
    using System.Text.RegularExpressions;
     
    public class Test
    {
     
        public static void Main()
        {
            string s = @"Hello John these are the files you have to send us today: 
                C:\projects\orders20101130.docx also we would like you to send 
                C:\some\file.txt, C:\someother.file and d:\some file\with spaces.ext  
   
                Thank you";
      
            Extract(s);
                    
        }
     
        private static readonly Regex rx = new Regex
            (@"[a-z]:\\(?:[^\\:]+\\)*((?:[^:\\]+)\.\w+)", RegexOptions.IgnoreCase);
     
        static void Extract(string text)
        {
            MatchCollection matches = rx.Matches(text);
     
            foreach (Match match in matches)
            {
                Console.WriteLine("'{0}'", match.Value);
            }
        }
     
    }
