    class Item
    {
        public string Name { get; set; }
        private Owner owner = null;
        public Owner Owner
        {
            get { return owner; }
            set
            {
                owner = value;
                Console.WriteLine($"I am {Name} and I am now owned by {(owner != null ? owner.Name : "no one")}");
            }
        }
    }
