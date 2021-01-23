    public string Rank
    {
        get
        {
           if (Parent == null)
           {
              return null;
           }
           if (Parent.Parent == null)
           {
              return Position.ToString();
           }
           return Parent.Rank + "." + Position.ToString();
        }
    }
