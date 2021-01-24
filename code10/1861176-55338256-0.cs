    class SomeClass : Form {
      private readonly Button b;
    
      public SomeClass() {
        b = new Button();
      }
    
      public SomeClass(Container x): this() {
        // Something else...
      }
    }
