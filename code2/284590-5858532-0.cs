    public interface IImageLogBuilder
    {
        void Log(string message);
    }
    
    //The class below IMPLEMENTS the IImageLogBuilder interface
    public class MyImageLogBuilder : IImageLogBuilder
    {
       //Implement IImageLogBuilder methods here
       public void Log(string message)
       {
          //Log message
       }
    }
