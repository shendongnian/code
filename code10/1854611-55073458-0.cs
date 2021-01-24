    class Program
    {
        static void Main(string[] args)
        {
            var mylist1 = new List<MyClass1>();
            mylist1.Add(new MyClass1 { id = 1, Name1 = "1" });
            mylist1.Add(new MyClass1 { id = 2, Name1 = "2" });
    
            var mylist2 = new List<MyClass2>();
            mylist2.Add(new MyClass2 { id = 1, Name2 = "1" });
    
            var location = from l in mylist1
                           join e in mylist2 on l.id equals e.id into rs1
                           from e in rs1.DefaultIfEmpty()
                           //where ids.Contains(l.ID)
                           select new
                           {
                               EquipmentClass = e,
                               InServiceStatus = e == null ? 1 : e.id,
                               EquipmentType = e.id
                           };
    
            foreach (var item in location)
            {
    
            }
        }
    }
    class MyClass1
    {
        public int id { get; set; }
        public string Name1 { get; set; }
    }
    
    class MyClass2
    {
        public int id { get; set; }
    
        public string Name2 { get; set; }
    }
