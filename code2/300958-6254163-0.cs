    public class Item
    {
        public int Id { get; private set; }
        public int Category { get; set; }
        public string Name { get; set; }
        public Item(int id, int category, string name)
        {
            this.Id = id;
            this.Category = category;
            this.Name = name;
        }
    }
