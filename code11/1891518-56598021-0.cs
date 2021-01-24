    class Program
    {
        static void Main(string[] args)
        {
            MyClass object1 = new MyClass(1, "A", new DateTime(2019, 1, 1));
            MyClass object2 = new MyClass(2, "B", new DateTime(2019, 1, 2));
            List<MyClass> myList = new List<MyClass>();
            myList.Add(object1);
            myList.Add(object2);
            string json = JsonConvert.SerializeObject(myList);
            List<MyClass> objectAfterJson = JsonConvert.DeserializeObject<List<MyClass>>(json);
            int id = objectAfterJson[0].Id;
        }
    }
    class MyClass
    {
        public int Id;
        public string Name;
        public DateTime Date;
        public MyClass(int id, string name, DateTime date)
        {
            Id = id;
            Name = name;
            Date = date;
        }
    }
