    public partial class Doc
    {
        public void AddDocItem(DocItem item)
        {
            var items = Items;
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = item;
            Items = items;
        } 
        public void PrintDocItems()
        {
            foreach (var item in Items)
                Console.WriteLine(item.Text);
        }
    }
