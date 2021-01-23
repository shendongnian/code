    class Pokemon
    {
        //Properties
        public string Name { get; set; }
        public Element ElementalType { get; set; }
        //Constructor
        public Pokemon(string name, Element type)
        {
            this.Name = name;
            this.ElementalType = type;
        }
    }
