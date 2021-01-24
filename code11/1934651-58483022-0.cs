     class Program
        {
            static void Main(string[] args)
            {
                var json_str = "{ table1:[{name:'data1'}," +
                    "{name:'data2'},{name:'data3'}]," +
                    "table2:[{name:'data1'},{name:'data2'},{name:'data3'}]}";
    
                var collection = JsonConvert.DeserializeObject<TableCollectionObject>(json_str);
    
                foreach (var item in collection.table1)
                {
                    Console.WriteLine(item.name);
                }
    
                foreach (var item in collection.table2)
                {
                    Console.WriteLine(item.name);
                }
    
                Console.ReadLine();
    
            }
        }
    
        class TableCollectionObject
        {
            public ICollection<SingleTableObject> table1 { get; set; }
            public ICollection<SingleTableObject> table2 { get; set; }
        }
    
        class SingleTableObject
        {
            public string name { get; set; }
        }
