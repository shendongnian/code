    // Example class
    public class RineItem
    {
        public string Name { get; set; }
        public int Id { get; set; }
        // Override ToString() for correct displaying in listbox
        public override string ToString()
        {
            return "Name: " + this.Name;
        }
    }
    public MainWindow()
    {
        InitializeComponent();
        // Adding some examples to our empty box
        this.ListBox1.Items.Add(new RineItem() { Name = "a", Id = 1 });
        this.ListBox1.Items.Add(new RineItem() { Name = "b", Id = 2 });
        this.ListBox1.Items.Add(new RineItem() { Name = "c", Id = 3 });
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // Loop through SelectedItems
        foreach (var item in this.ListBox1.SelectedItems)
        {
            // Have a look at it's type. It is our class!
            Console.WriteLine("Type: " + item.GetType()); 
            // We cast to the desired type
            RineItem ri = item as RineItem;
            // And we got our instance in our type and are able to work with it.
            Console.WriteLine("RineItem: " + ri.Name + ", " + ri.Id); 
            // Let's modify it a little
            ri.Name += ri.Name;
            // Don't forget to Refresh the items, to see the new values on screen
            this.ListBox1.Items.Refresh();
        }
    }
