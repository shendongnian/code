    using System;
    using System.IO;
    using Microsoft.VisualBasic.FileIO; //Microsoft.VisualBasic.dll
    
    public class Sample {
        static void Main(){
            string data = "1014,'0,1031,1032,1034,1035,1036',0,0,1,1,0,1,0,-1,1";
            string[] fields = null;
            data = data.Replace('\'', '"');
            using(var csvReader = new TextFieldParser(new StringReader(data))){
                csvReader.SetDelimiters(new string[] {","});
                csvReader.HasFieldsEnclosedInQuotes = true;
                fields = csvReader.ReadFields();
            }
            foreach(var item in fields){
                Console.WriteLine("{0}",item);
            }
        }
    }
