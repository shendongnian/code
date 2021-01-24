        class Program
        {
            static void Main(string[] args)
            {
                StreamWriter writer = new StreamWriter("Filename");
                List<Record> data = new List<Record>();
                foreach (Record record in data)
                {
                    string line = string.Join(",", record.field1, record.field2, record.field3, record.field4, record.field5);
                    writer.WriteLine(line);
                }
                writer.Flush();
                writer.Close();
            }
        }
        public class Record
        {
            public string field1 { get; set; }
            public string field2 { get; set; }
            public string field3 { get; set; }
            public string field4 { get; set; }
            public string field5 { get; set; }
        }
