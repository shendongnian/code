    class BaseClass
    {
         protected virtual string Something
         {
             get { return ""; }
         }
    
         public string GetValueOfSomething()
         {
             return this.Something;
         }
    }
