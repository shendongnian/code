    MyClass{
      
      private AnotherClass _another = new AnotherClass();
    
      public string ABC(){
        return _another.XYZ();
      }
    }
    
    public AnotherClass{
      //Context comes from somewhere...
      public string XYZ(){
        return context.request.querystring["id"]
      }
    }
