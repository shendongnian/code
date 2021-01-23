    public interface ISerializationErrorWriter
    {
        bool Result { set; get; }
        string EngineErrorMessage { set; get; }
    }
    public class MyClass1 : ISerializationErrorWriter
    {
        public string MyProperty2 { get; set; }
        public bool Result { get; set; }
        public string EngineErrorMessage { get; set; }
    }
    public class MyClass2 : ISerializationErrorWriter
    {
        public string MyProperty2 { get; set; }
        public bool Result { get; set; }
        public string EngineErrorMessage { get; set; }
    }
    // Option 1:
    public void Serialization_1<T>(ref T engine) where T : ISerializationErrorWriter
    {
        try
        {
            //Do some work with passed class
        }
        catch (Exception e)
        {
            engine.Result = false;
            engine.EngineErrorMessage = e.Message;
        }
    }
    // Option 2:
    public void Serialization_2<T>(ref T engine)
    {
        try
        {
            //Do some work with passed class
        }
        catch (Exception e)
        {
            var serializationErrorWriter = engine as ISerializationErrorWriter;
            if(serializationErrorWriter != null)
            {
                serializationErrorWriter.Result = false;
                serializationErrorWriter.EngineErrorMessage = e.Message;
            }
        }
    }
