    public class ThingIDontCareAbout: IAcceptsVisitor
    {
    }
    public class ThingICareAbout: IAcceptsVisitor
    {
      public bool Visited { get; set; }
      public AdvancedElement()
      {
        Visited = false;
      }
    }
    public class Visitor
    {
      public void Visit( IAcceptsVisitor e )
      {
        dynamic d = e;
        this.DynamicVisit( d );
      }
      private void DynamicVisit( IAcceptsVisitor e )
      {
        // Do nothing.
      }
      private void DynamicVisit( ThingICareAbout e )
      {
        e.Visited = true;
      }
    }
