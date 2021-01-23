    using System;
    using System.IO;
    using Newtonsoft.Json;
    
    public class From
    {
        public string name;
        public int id; 
    }
    public class Target
    {
        public string id;
        public From from = new From();
    }
    public class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText(@"c:\temp\json.txt");
            Target newTarget = JsonConvert.DeserializeObject<Target>(json);
        }
    }
