    class Pokemon
    {
        //Properties
        public string Name { get; set; }
        public ElementalType ElementalType { get; set; }
        //Constructor
        public Pokemon(string name, ElementalType type)
        {
            this.Name = name;
            this.ElementalType = type;
        }
    }
