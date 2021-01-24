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
                    if (value.Owner != null)
				   	{
					   	value.Owner.Item = null;
				   	}
                    value.Owner = this;
                }
			   	else
			   	{
				   	if (item != null)
				   	{
					   	item.Owner = null;
				   	}
			   	}
                item = value;
                Console.WriteLine($"I am {Name} and I now own {(item != null ? item.Name : "no one")}");
            }
        }
    }
