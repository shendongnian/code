    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    public class NumStrCmp : IComparer<string> {
        public int Compare(string x, string y){
            Regex regex = new Regex(@"(?<NumPart>\d+)(?<StrPart>\D*)",RegexOptions.Compiled);
            var mx = regex.Match(x);
            var my = regex.Match(y);
            var ret = int.Parse(mx.Groups["NumPart"].Value).CompareTo(int.Parse(my.Groups["NumPart"].Value));
            if(ret != 0) return ret;
            return mx.Groups["StrPart"].Value.CompareTo(my.Groups["StrPart"].Value);
        }
    }
    
    class Sample {
        static public void Main(){
            var data = new List<string>() {"10","10b","1111","1164","1174","23","23A","23B","23D","23E"};
            data.Sort(new NumStrCmp());
            foreach(var x in data){
                Console.WriteLine(x);
            }
       }
    } 
