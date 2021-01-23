    using System;
    using System.Text;
    using Microsoft.VisualBasic.FileIO; //Microsoft.VisualBasic.dll
    using System.IO;
    
    public class Sample {
        static void Main(){
            string str = "ZBEE10364,\"Cobler, CHARLOTTE J\",Whiskey,,Brandy,0:00:00,20110912,CHECK,2918,117.33,1,117.33,0,EDM0,Yu789";
            string[] strArr = str.Split(',');
            var reader = new StringReader(str);
            using(var csvReader = new TextFieldParser(reader)){
                csvReader.SetDelimiters(new string[] {","});
                csvReader.HasFieldsEnclosedInQuotes = true;
                strArr = csvReader.ReadFields();
            }
    
            //check print
            foreach(var item in strArr){
                Console.WriteLine("\"{0}\"",item);
            }
        }
    }
