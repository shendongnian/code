    class GenericNode
    {
      private List<GenericNode> _Nodes = new List<GenericNode>();
	  private List<GenericKeyValue> _Attributes = new List<GenericKeyValue>();
	  public GenericNode(XElement Element)
	  {
	     this.Name = Element.Name;
		 this._Nodes.AddRange(Element.Elements()
                                     .Select(e => New GenericNode(e));
		 this._Attributes.AddRange(
                    Element.Attributes()
                           .Select(a => New GenericKeyValue(a.Key, a.Value))
	  }
   
      public string Name { get; private set; }
	  public IEnumerable<GenericNode> Nodes
	  {
		get
		{
		   return this._Nodes;
		}		
	  }
	  public IEnumerable<GenericKeyValue> Attributes
	  {
	    get
		{
		   return this._Attributes;
		}
	  }
    }
   
    class GenericKeyValue
    {
      public GenericKeyValue(string Key, string Value)
	  {
	     this.Key = Key;
		 this.Value = Value;
	  }
      public string Key { get; set; }
	  public string Value { get; set; }
    }
