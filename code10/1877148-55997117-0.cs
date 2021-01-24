    class A
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
    class B
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
    
    var items = new List<object>()
    {
        new B { Name = "B", Value = 1 },
        new B { Name = "A", Value = 2 }
    };
    var target = new A { Name = "A", Score = 1 };
    object match = items
    .Find(o => o.GetType().GetProperty("Name").GetValue(o) == target.Name ); 
    //Here would be your object
