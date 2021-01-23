    class Jooky 
    {
        static long Last;
        public Jooky(Flooky parent) 
        {
            Id += Last++; 
            Parent = parent;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public Flooky Parent { get; private set; }
    }
