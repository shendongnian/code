    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication152
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataBase db = new DataBase();
                string[] labels = db.MpttModel.Where(x => (x.Lft.CompareTo(x.Rght) <= 0) && (x.Id.CompareTo("8761620FA1B0DD4AB852324AACE0FEF3") >= 0) && (x.Id.CompareTo("45E88A219EE0A347B51DFD8A6417C806") <=0)).Select(x => x.Label).ToArray();
            }
        }
        public class DataBase
        {
            public List<MpttModel> MpttModel { get; set; } 
        }
        public class MpttModel
        {
            public string Label { get; set; }
            public string Lft { get; set; }
            public string Rght { get; set; }
            public string Id { get; set; }
        }
    }
