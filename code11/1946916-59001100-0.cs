    class Bear
    {
        public Bear(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }
    }
    
    class Cave
    {
        List<Bear> cave = new List<Bear>();
        public Cave()
        {
            cave.Add(new Bear(16, "Johnny"));
            cave.Add(new Bear(10,"Herman"));
        }
    }
