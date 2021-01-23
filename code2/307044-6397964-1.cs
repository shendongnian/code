    public class classRoot
    {
      public string Name { get; set; }
      public virtual void assignFrom(myRootClass objSource)
      {
         if (objSource != null) {
           this.Name = objSource.Name;
         }
      }
      public virtual void assignTo(ref myRootClass objDest)
      {
         if (objDest != null) {
           objDest.Name = this.Name;
         }
      }
    }
    public class classFoo: classRoot
    {
      public Color Color { get; set; }
      public override void assignFrom(myRootClass objSource) { updateChanges(); }
      public override void assignTo(ref myRootClass objDest) { updateChanges(); }
    }
    public class classBar: classRoot
    {
      public int Age { get; set; }
      public override void assignFrom(myRootClass objSource) { updateChanges(); }
      public override void assignTo(ref myRootClass objDest) { updateChanges(); }
    }
    public class classDemo
    {
      public void anyMethod()
      {
        classFoo objFoo = new classFoo("Foo1");
        classFoo objBar = new classBar("Bar2");
        MessageBox.Show("Name: " + objFoo);
        objBar.AssignTo(ref objFoo);
        MessageBox.Show("Name: " + objFoo);
      }
    }
