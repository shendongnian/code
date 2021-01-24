    //Rextester.Program.Main is the entry point for your code. Don't change it.
    //Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5
    
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
                //Your code goes here
                List<string> errorList = new List<string>();
                List<string> newList = new List<string>();
                errorList.Add("one error");
                errorList.Add("some text");
                errorList.Add("two error");
                errorList.Add("some text");
                errorList.Add("some text");
                errorList.Add("some text");
                errorList.Add("three error");
                errorList.Add("four error");
                errorList.Add("some text");
                errorList.Add("some text");
                foreach(string item in errorList){
                    if(item.Contains("error")){
                        newList.Add(item);
                    }
                }
                
                foreach(string item in newList){
                    Console.WriteLine(item);
                }
            }
        }
    }
