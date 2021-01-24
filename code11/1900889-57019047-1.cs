    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace Rextester
    {
     public class Program
     {
        public static void Main(string[] args)
        {
            Program prog = new Program();
            Dictionary<String,String> output = prog.splitString("status=ACCEPTED&code=12345&type=CARD&id=98765");
            Console.WriteLine(output["status"]);
            
        }
        
        public Dictionary<string,string> splitString(string text) {
          Dictionary<string,string> output = new Dictionary<string,string>();
            if(text != null) {
                string[] keyValueArray = text.Split('&');
                foreach(string keyVal in keyValueArray) {
                    string[] finalSplit = keyVal.Split('=');
                    output.Add(finalSplit[0],finalSplit[1]);
                }
            }
            return output;
        }
      }
    }
 
