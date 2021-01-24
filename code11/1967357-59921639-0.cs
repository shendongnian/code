    public class TextClass
    {
        // No mutable properties (ideally replace List with IReadonlyCollection too)
        public List<string> Words { get; }
        public string Text { get; }
        public string Name { get; }
        public string Date { get; }
        public string Id { get; }
        public TestClass (List<string> words, string text, string name, string date, string id)
        {
           this.Words = words ?? throw new ArgumentNullException(nameof(words));
           ...
        }
        public TestClass WithNewText(string text) =>
           new TestClass(this.Words, text, this.Name, this.Date, this.Id);
     }
