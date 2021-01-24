    class Program
    {
        static void Main(string[] args)
        {
            Guid guid1 = Guid.NewGuid();
            List<Item> items = new List<Item>()
            {
                new Item
                {
                    ID = guid1,
                    Priority = 1
                },
                new Item
                {
                    ID = guid1,
                    Priority = 2
                },
                new Item
                {
                    ID = guid1,
                    Priority = 3
                },
                new Item
                {
                    ID = Guid.NewGuid(),
                    Priority = 1
                },
                new Item
                {
                    ID = Guid.NewGuid(),
                    Priority = 2
                },
                new Item
                {
                    ID = Guid.NewGuid(),
                    Priority = 3
                },
            };
            //IF YOU CAN CHANGE THE LIST
            items = items.GroupBy(x => x.ID).Select(x => x.OrderByDescending(y => y.Priority).First()).ToList();
            //IF YOU CAN CHANGE ONLY LIST ITEMS
            items.RemoveAll(z => items.GroupBy(x => x.ID).SelectMany(x => x.OrderByDescending(y => y.Priority).Skip(1).ToList()).ToList().Contains(z));
        }
    }
    public class Item
    {
        public Guid ID { get; set; }
        public int Priority { get; set; }
    }
