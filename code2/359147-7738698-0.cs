    public MyClassEqualityComparer:IEqualityComparer<MyClass>
    {
      private static FieldInfo personNameField=typeof(MyClass).GetField("_personName",BindingFlags.NonPublic);
      private static FieldInfo idField=typeof(MyClass).GetField("_id",BindingFlags.NonPublic);
    
      public bool Equals(MyClass o1,MyClass o2)
      {
        if(o1==o2)
          return true;
        if(o1==null||o2==null)
          return false;
        string name1=(string)personNameField.GetValue(o1);
        string name2=(string)personNameField.GetValue(o2);
        if(name1!=name2)
          return false;
        Guid id1=(Guid)idField.GetValue(o1);
        Guid id2=(Guid)idField.GetValue(o2);
        return id1==id2;
      }
      public int GetHashCode(MyClass o)
      {
        string name=(string)personNameField.GetValue(o);
        Guid id=(Guid)idField.GetValue(o);
        return name.GetHashCode()^id.GetHashCode();
      }
    }
