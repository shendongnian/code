    public class X {
    
      public void XX(string z) { }
    
    }
    
    public class Y : X {
    
      private new int XX { get; set; }
    
    }
    X x = new Y();
    x.XX();
    
    Y y = new Y();
    y.XX = 42;
