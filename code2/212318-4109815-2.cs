    using System;
    using System.IO;
    using Newtonsoft.Json;
    
    public class NameAndId
    {
        public string name;
        public int id; 
    }
    public class Data
    {
        public NameAndId[] data;
    }
    public class Target
    {
        public string id;
        public NameAndId from;
        public Data likes;
    }
    public class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText(@"c:\temp\json.txt");
            Target newTarget = JsonConvert.DeserializeObject<Target>(json);
        }
    }
