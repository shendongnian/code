    public int GetHashCode(MyType obj)
    {
       return obj.Prop1.GetHashCode() ^ 
              obj.Prop2.GetHashCode() ^ 
              obj.Prop3.GetHashCode();
    }
