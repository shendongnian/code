    class person
    {
        public string name { get; set; }
        public int age { get; set; }
    }
    ...
    string name = "noName";
    name = Console.ReadLine();
    person kalle = new person();
    kalle.name = name;
