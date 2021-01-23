    Interface ISecurity {
      void UpdateVarX(int value);
      void UpdateVarY(int value);
      int GetValueX();
      int GetValueX();
    }
    
    class Foo:ISecurity {
      // Implement methods of the interface
    }
    
    class Bar:ISecurity {
      // Implement methods of the interface
    }
    
    class Yoo:ISecurity {
      // Implement methods of the interface
    }
    
    // This class is the class that uses your other classes
    class Consumer 
    {
      private ISecurity sec;
    
      public Consumer(ISecurity sec) {
        sec.UpdateVarX(25);
      }
    }
