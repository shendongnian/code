    public class TextClass
    {
        // You don't need to set the list externally, just get it to add/remove/iterate
        public List<string> Words { get; } = new List<string>();
        public string Text { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Id { get; set; }
        public TestClass Copy()
        {
            var copy = new TestClass()
            {
                Text = this.Text;
                Name = this.Name;
                Date = this.Date;
                Id = this.Id;
            }
            copy.Words.AddRange(this.Words); // this ensures a deep copy of the list
            return copy;
        }    
    }
