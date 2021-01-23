    XDocument doc;
    Dictionary<string,int> dict;
    public myObject()
    {
      doc = XDocument.Load(@"xmldocument.xml");
      dict = new Dictionary<string,int>();
    }
    public int Description{
     get{
      if(!dict.ContainsKey(ValueB))
        dict.Add( ValueB, 
                  (int)doc.Elements("test").Single(t => t.Element(ValueB).Value));
      return dict[ValueB];
      }
    }
