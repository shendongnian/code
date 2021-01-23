    public class OtherClass
    {
       IBaseline GenericInstance;
       
       public OtherClass(IBaseline instance)
       {
            GenericInstance=instance;
       }
    
       public void CommonAccessFunction()
       {
          // call the common function that is generic no matter WHAT 
          // subclassed instance is used.
          GenericInstance.CommonFunction();
       }
    }
