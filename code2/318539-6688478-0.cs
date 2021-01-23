    using System.IO;
    using LumenWorks.Framework.IO.Csv;
    static class Program
    {
        public class MyObject
        {
            public int Prop1 { get; set; }
            public string Prop2 { get; set; }
            public decimal Prop3 { get; set; }
        }
        void ReadCsv()
        {
            //holds the property mappings
            Dictionary<string, int> myObjectMap = new Dictionary<string, int>();
            List<MyObject> myObjectList = new List<MyObject>();
            // open the file "data.csv" which is a CSV file with headers
            using (CsvReader csv = new CsvReader(new StreamReader("data.csv"), true))
            {
                int fieldCount = csv.FieldCount;
                string[] headers = csv.GetFieldHeaders();
                for (int i = 0; i < fieldCount; i++)
                {
                    myObjectMap[headers[i]] = i; // track the index of each column name
                }
                while (csv.ReadNextRecord())
                {
                    MyObject myObj = new MyObject();
                    myObj.Prop1 = csv[myObjectMap["Prop1"]];
                    myObj.Prop2 = csv[myObjectMap["Prop2"]];
                    myObj.Prop3 = csv[myObjectMap["Prop3"]];
                    myObjectList.Add(myObj);
                }
            }
        }
    }  
