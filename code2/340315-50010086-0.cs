    namespace WebProject
    {
       public interface IProfile
       {...}
    
       class MyWrapperClass : IProfile
       {
          private IProfile _wrapped;
       }
    }
