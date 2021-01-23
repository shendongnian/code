    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using Microsoft.VisualBasic.FileIO; //Microsoft.VisualBasic.dll
    using System.IO;
    
    public class Sample {
        static void Main(){
            string data = "[a, b, [c, [d, e]], f, [g, h], i]";
            string[] fields = StringToArray(data);
            //check print
            foreach(var item in fields){
                Console.WriteLine("\"{0}\"",item);
            }
        }
        static string[] StringToArray(string data){
            string[] fields = null;
            Regex innerPat = new Regex(@"\[\s*(.+)\s*\]");
            string innerStr = innerPat.Matches(data)[0].Groups[1].Value;
            StringBuilder wk = new StringBuilder();
            var balance = 0;
            for(var i = 0;i<innerStr.Length;++i){
                char ch = innerStr[i];
                switch(ch){
                case '[':
                    if(balance == 0){
                        wk.Append('"');
                    }
                    wk.Append(ch);
                    ++balance;
                    continue;
                case ']':
                    wk.Append(ch);
                    --balance;
                    if(balance == 0){
                        wk.Append('"');
                    }
                    continue;
                default:
                    wk.Append(ch);
                    break;
                }
            }
            var reader = new StringReader(wk.ToString());
            using(var csvReader = new TextFieldParser(reader)){
                csvReader.SetDelimiters(new string[] {","});
                csvReader.HasFieldsEnclosedInQuotes = true;
                fields = csvReader.ReadFields();
            }
            return fields;
        }
    }
