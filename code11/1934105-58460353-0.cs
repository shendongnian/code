class NavElement { 
        public string Text { get; set; }
        public string Location { get; set; }
        public List<NavElement> SubElements { get; set; }
    }
    private static void Main()
    {
        List<NavElement> navElements = new List<NavElement> {
        new NavElement{Text = "1", Location = "1", SubElements = new List<NavElement> {
            new NavElement{Text = "1-1", Location = "1-1", SubElements = new List<NavElement> {
                new NavElement{Text = "1-1-1", Location = "1-1-1"},
                new NavElement {Text = "1-1-2", Location = "1-1-2"},
                new NavElement {Text = "1-1-3", Location = "1-1-3"}
            } },
            new NavElement {Text = "1-2", Location = "1-2", SubElements = new List<NavElement> {
                new NavElement {Text = "1-2-1", Location = "1-2-1"},
                new NavElement {Text = "1-2-2", Location = "1-2-2"},
                new NavElement {Text = "1-2-3", Location = "1-2-3"}
            } },
            new NavElement {Text = "1-3", Location = "1-3", SubElements = new List<NavElement> {
                new NavElement {Text = "1-3-1", Location = "1-3-1"},
                new NavElement {Text = "1-3-2", Location = "1-3-2"},
                new NavElement {Text = "1-3-3", Location = "1-3-3"}
            } }
        } }
        };
With this schema, you can access the properties and the children without reflection. 
Console.WriteLine(navElements[0].SubElements[2].SubElements[2].Text); 
will print
1-3-3
