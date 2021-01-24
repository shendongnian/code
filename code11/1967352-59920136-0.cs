    public class TextClass
    {
        // You don't to be able to set the list externally, just get it to add/remove/iterate
        public List<string> Words { get; } = new List<string>();
        public string Text { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Id { get; set; }
        public TestClass() { } // default constructor
        public TestClass(TestClass from) // copy constructor
        {
            Text = from.Text;
            Name = from.Name;
            Date = from.Date;
            Id = from.Id;
            Words.AddRange(from.Words); // this ensures a deep copy of the list
        }    
    }
