    class Primary {
      public int x1, x2, x3;   //data that is read from file or calculated
      private ILoader _loader;
      public Primary(ILoader loader) {
        _loader = loader;
      }
      public Primary() {
        _loader = new Loader();
      }
    
      public void LoadPrimary {
        _loader.Load(this); 
      }
    
      public void DoStuff() {
        x1++; x2--;
      }
    }
    
    interface ILoader {
      void Load(Primary primToLoad);
    }
    class Loader : ILoader {
      public void Load(Primary PrimToLoad) {
        L.x1 = 2; L.x2 = 4; 
        L.DoStuff();   //call a method in the calling class (better way for this?)
        L.x3 = 6;
      }
    }
    
    class Stub {
      public void SomeMethod() {
        Primary P = new Primary(new Loader());
        P.LoadPrimary();
      }
    }
    
    
