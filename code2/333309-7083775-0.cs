    public Collection<Node> Siblings { /* see below */ }
    public Collection<Node> Children { get; set; }
    public Node Parent { get; set; }
    public int Position 
    { 
       get 
       { 
          return (Parent == null) 
             ? 0  // I don't like magic numbers, but I don't want to make this an int? either
             : Siblings.IndexOf(this) + 1; 
       }
    }
    public string Rank
    {
        get
        {
           return (Parent == null)
              ? Position.ToString()
              : Parent.Rank + "." + Position.ToString();
        }
    }
