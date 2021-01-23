    class C1 {
      public object Prop1 { get; set; }
    };
    
    var local = new C1();
    local.Prop1 = local;
    var x = local.GetHashCode();  // Infinite recursion
