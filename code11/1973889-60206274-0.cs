    using System;
    using System.Collections.Generic;
    using Json.Net;
    
    namespace ConsoleApp
    {
        internal class Program
        {
            public static void Main(string[] args)
            {
                string input= "{\"status\":404,\"userMessage\":\"ERROR CODE: EBE04005 | SEVERITY: E | SOURCE IDENTIFIER: EBE04 | DESCRIPTION: The User Profile Retrieval Service was unable to process due to an unavailable Data Source: | Additional Info: Prodcucer Detail Not Found In Producer DB For Producer Code: 123456\"}";
    
                Data data = JsonNet.Deserialize<Data>(input);
    
                string[] messages = data.userMessage.Split('|');
                
                Dictionary<string, string> messageDict = new Dictionary<string, string>();
                
                foreach (string message in messages)
                {
                    string[] tmp = message.Split(':');
                    messageDict.Add(tmp[0].Trim(), tmp[1].Trim());
                }
    
                foreach (string key in messageDict.Keys)
                {
                    Console.WriteLine($"Key: {key} Value: {messageDict[key]}");
                }
            }
        }
    
        public class Data
        {
            public int status { get; set; }
    
            public string userMessage { get; set; }
        }
    }
