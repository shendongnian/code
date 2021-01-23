    public MyClass : IFoo   
    {
       public void CallAllMethodsOfIIMethodImpl()
       {
           if (this.MethodCaller != null)
           {
              this.MethodCaller.Add( ... );
              this.MethodCaller.Delete( ... );
              this.MethodCaller.Update( ... );
           }
       }
    }
