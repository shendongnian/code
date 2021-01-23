    public class LogBinaryWriter : ILogBinaryWriter
    {
       private readonly IImageLogBuilder _imageLogBuilder;
       
       public LogBinaryWriter(IImageLogBuilder imageLogBuilder)
       {
          _imageLogBuilder = imageLogBuilder;
       }
    ....
    
    
    }
