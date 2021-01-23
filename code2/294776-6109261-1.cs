    public IEnumerable<XElement> Elements
    {
        get
            {
                var doc = XDocument.Load(@"\abc.xml");
                var windows = doc.Root.Elements();
                return windows;
            }
    }
