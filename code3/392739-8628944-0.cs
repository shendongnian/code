    public class Item
    {
        public List<double> x = new List<double>();
        public List<double> y = new List<double>();
    }
    
    static void Main(string[] args)
    {
        CheckedListBox box = new CheckedListBox();
        box.Items.OfType<Item>().ToList();
    }
