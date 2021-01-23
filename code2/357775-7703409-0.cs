    // use "Microsoft.VisualBasic.dll"
    
    using System;
    using Microsoft.VisualBasic.FileIO;
    
    class Program {
        static void Main(string[] args){
            using(var csvReader = new TextFieldParser(@"sportsResults.csv")){
                csvReader.SetDelimiters(new string[] {","});
                string [] fields;
                while(!csvReader.EndOfData){
                    fields = csvReader.ReadFields();
                    Console.WriteLine(String.Join(",",fields));//replace make instance
                }
            }
        }
    }
