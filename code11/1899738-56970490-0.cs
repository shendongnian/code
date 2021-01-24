    public class BaseModule
    {
        public string UsedSource {get; set;}
    
        public Write(string text)
        {
            OtherStaticClass.Log(UsedSource, text);
        }
    }
