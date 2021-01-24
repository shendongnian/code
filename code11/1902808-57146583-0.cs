    public interface ICoreApplication
    {
        //These are the methods that you want to provide to your plugins:
        void LogMessage(string msg);
        //void SomeOtherMethod(...)
        //...
    }
    public interface IPlugin
    {
        //These are the methods that you expect from your plugins:
        void Init(ICoreApplication coreReference);
    }
