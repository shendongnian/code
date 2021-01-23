    void Main()
    {
    	var doc = XElement.Parse(
    	    @"<root>
            <data>
                <file>file1</file>
                <a>nodea</a>
                <b>nodeb</b>
                <c>nodec</c>
            </data>
            <data>
                <file>file2</file>
                <a>node2a</a>
                <b>node2b</b>
                <c>node2c</c>
            </data>
            </root>");
        // Or use XElement.Load to load from file, stream, URI, etc.
    	
    	List<Data> mylist =
            doc.Elements()
                .Select(
                    x =>
                    new Data
                    {
                        File = x.Element("file").Value,
                        A = x.Element("a").Value,
                        B = x.Element("b").Value,
                        C = x.Element("c").Value})  // or call constructor
                .ToList();
                
        mylist.Dump();  // LINQPad extension to display output
    }
    
    public class Data
    {
        public string File { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
    }
