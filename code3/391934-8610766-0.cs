    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    class Sample {
        static public void Main(){
            var data = "8A65";
            Regex regex = new Regex(@"(?<hex>[0-9A-F]{2})",RegexOptions.IgnoreCase | RegexOptions.Compiled);
            byte[] bytes = regex.Matches(data).OfType<Match>().Select(m => Convert.ToByte(m.Groups["hex"].Value,16)).ToArray();
            char[] chars = Encoding.GetEncoding(932).GetChars(bytes);
            Console.WriteLine(new String(chars));
       }
    } 
