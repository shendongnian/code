    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                MT940 mt940 = new MT940(FILENAME); 
            }
        }
        public class MT940
        {
            public MT940(string filename)
            {
                StreamReader reader = new StreamReader(filename);
                string line = "";
                int transactionCount = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if(line.StartsWith(":"))
                    {
                        string[] splitLine = line.Split(new char[] {':'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        switch(splitLine[0])
                        {
                            case "20":
                                senderReference = splitLine[1];
                                break;
                            case "25" :
                                authorisation = splitLine[1];
                                break;
                            case "28C" :
                                messageIndexTotal = splitLine[1];
                                break;
                            case "60F":
                                openingBalance = splitLine[1];
                                break;
                            case "61":
                                if (++transactionCount == 1)
                                {
                                    firstTransaction = splitLine[1];
                                }
                                else
                                {
                                    secondTransaction = splitLine[1];
                                }
                                break;
                            case "62F":
                                closingBalance = splitLine[1];
                                break;
                            default :
                                break;
                        }
                    }
                }
            }
            public string senderReference { get; set; }  //code 20
            public string authorisation { get; set; } // tag 25
            public string messageIndexTotal { get; set; } //tag 28D
            public string openingBalance { get; set; }  //60F
            public string firstTransaction { get; set; } //61
            public string secondTransaction { get; set; } //61
            public string closingBalance { get; set; } //62F
        }
    }
