    class MyClass
    {
        private static List<MyClass> instances = new List<MyClass>();
    
        public int ID { get; set; }
        public string Name { get; set; }
        
        public MyClass(int id, string name)
        {
            this.ID = id;
            this.Name = name;
            instances.Add(this);
        }
    
        public override string ToString()
        {
            return string.Format("ID = {0}, Name = {1}", this.ID, this.Name);
        }    
    
        public Method()
        {
            instances.ForEach(mc => Console.WriteLine(mc.ToString()));
        }
    }
