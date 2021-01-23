    class MyClass
    {
        public int VAR1;
        public int VAR2;
    
        private MyClass()
        {
        }
    
        public static MyClass MakeInstance(int var1, int var2)
        {
            if(var1==var2)
            {
                return new MySubClass1(var1, var2);
            }
            else
            {
                return new MySubClass2();
            }
        }
    }
    class MySubClass1 : MyClass
    {
    
        public MySubClass1(int var1, int var2)
        {
                this.VAR1=var1;
                this.VAR2=var2;
        }
        public int DoMath()
        {
            return this.VAR1+this.VAR2;
        }
    }
    class MySubClass2 : MyClass
    {
      public MySubClass2()
      {
      }
      //Same as MySubClass1 except no DoMath()
    }
