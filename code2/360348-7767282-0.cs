    public MyClass : IFoo
     { 
       private TestClass _inst;
       public IMethod MethodCaller
       { 
         get 
            {
             if(_inst==null)
               _inst=new TestClass();
             return _inst;
            }
          set 
            {
              _inst=value;
             }  
        }
       public class TestClass : IMethod
       {
         public String Add(string str) {}
         public Boolean Update(string str) {}
         public Boolean Delete(int id) {}
       }
     }
