    interface IAnotherClass{
      string XYZ();
    }
    
    MyClass{  
      private IAnotherClass _another = new AnotherClass();
    
      public MyClass(IAnotherClass anotherClass){
        _another = anotherClass;
      }
    
      public string ABC(){
        return _another.XYZ();
      }
    }
    
    public AnotherClass: IAnotherClass{
      //Context comes from somewhere...
      public string XYZ(){
        return context.request.querystring["id"]
      }
    }
