    public class OtherClass<T> where T : IBaseline
    {
       T GenericInstance;
       ...
       ...
    
       public void CommonAccessFunction()
       {
          // call the common function that is generic no matter WHAT 
          // subclassed instance is used.
          GenericInstance.CommonFunction();
       }
    }
