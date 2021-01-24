    class Owner
    {
        public string Name { get; set; }
        private Item item = null;
        public Item Item
        {
            get { return item; }
            set
            {
                if (value != null)
                {
                    value.Owner = this;
                }
                item = value;
                Console.WriteLine($"I am {Name} and I now own {(item != null ? item.Name : "no one")}");
            }
        }
    }
