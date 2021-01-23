    public class Bar
    {
      public Bar()
      {
        Gizmo g = new Gizmo();
        g.Foo += new EventHandler(FooHandler);
    
      }
    
      public void FooHandler(object sender, EventArgs e)
      {
        //do stuff..
        this  //Does the "this" keyword mean something in this context?
      }
    }
