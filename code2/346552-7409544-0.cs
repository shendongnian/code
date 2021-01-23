    class Person
    {
        public string Name { get; private set; }
        public Person Parent { get; private set; }
        public IList<Person> Children { get; private set; }
        private Person() {} // Private constructor
        public static Person CreatePersonNoParent(string name){*implementation elided*};
        public Person CreateChild(string name)
        {
            Person child = new Person { Name=name, Parent=this };
            this.Children.Add(child);
            return child;
        }
    }
