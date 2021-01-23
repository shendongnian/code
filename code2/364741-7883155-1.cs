    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    
    class Sample {
        static public void Main(){
            string s1 = "bc3231dsc";
            string s2 = "bc3462dsc";
            List<string> common_str = commonStrings(s1,s2);
            foreach ( var s in common_str)
                Console.WriteLine(s);
        }
        static public List<string> commonStrings(string s1, string s2){
            int len = s1.Length;
            char [] match_chars = new char[len];
            for(var i = 0; i < len ; ++i)
                match_chars[i] = (Char.ToLower(s1[i])==Char.ToLower(s2[i]))? '#' : '_';
            string pat = new String(match_chars);
            Regex regex = new Regex("(#+)", RegexOptions.Compiled);
            List<string> result = new List<string>();
            foreach (Match match in regex.Matches(pat))
                result.Add(s1.Substring(match.Index, match.Length));
            return result;
        }
    }
