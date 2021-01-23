    class A {
      public void Method() {
        B bee = new B{};
        try {
          bee.Read(name);
          bee.Write(name);
        } catch(Exception ex) {
          // handle exception if needed
        }
      }
    }
    
    class B {
      public void Read(string name) {
        try{
          ...
        } catch(Exception ex) {
          // handle exception if needed
          throw;
        }
      }
      public void Write(string name) {
      }
    }
