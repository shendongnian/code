    public int GetHashCode(MyType obj)
    {
      int hash = 0;
      unchecked
      {         
         hash += 19 * obj.Prop1.GetHashCode();
         hash += 31 * obj.Prop2.GetHashCode();
         hash += 37 * obj.Prop3.GetHashCode();
      }
      return hash;
    }
