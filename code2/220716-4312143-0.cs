     // lightweight data class thats shared
    public class Item
    {
        public int Weight { get; set;  }
        public string Name { get; set; }
    }
    // decorator pattern class that adds behaviour
    public class ServerItem
    {
        private Item item;
        public ServerItem(Item item)
        {
            this.item = item;
        }
        public void Use()
        {
            // do something with item;
        }
    }
    ServerItem currentServerItem = new ServerItem(currentItem);
