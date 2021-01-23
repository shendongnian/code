    public class PermissionDeniedException : Exception {}
    class MainClass : IInterface_1, IInterface_2 {
      public string field_1{set;get;}
      private string field_2{set;get;}
      string IInterface_1.field_2 {
        get {throw new PermissionDeniedException();}
        set {throw new PermissionDeniedException();}
      }
      public string field_3{set;get}
      public string field_4{set;get}
    }
