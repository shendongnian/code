    public class MyShort
    {
        public short Value {get; set;}
    }
    
    public class SomeOtherClass
    {
       public void SomeMethod()
       {
           MyShort[] array = new MyShort[2];
           array[0] = new MyShort {Value = 5};
           array[1] = new MyShort {Value = 2};
    
           array[0].Value = 3;
       }
    }
