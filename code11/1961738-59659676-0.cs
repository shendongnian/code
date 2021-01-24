    class Parent
    {
        int id;
        string name;
        List<Child> children;
    
        public Parent(int ID, string Name, List<Child> Children)
        {
            id = ID;
            name = Name;
            children = Children;
        }
    }
    
    class Child
    {
        int id;
        string name;
        List<string> values;
    
        public Child(int ID, string Name, List<string> Values)
        {
            id = ID;
            name = Name;
            values = Values;
        }
    }
