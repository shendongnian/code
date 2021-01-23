    class BC {
    
      public virtual void Display() {
        System.Console.WriteLine("BC::Display");
      }
    
    }
    
    class DC : BC {
    
      override public void Display() {
        System.Console.WriteLine("DC::Display");
      }
    
    }
