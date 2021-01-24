    public interface IPlugin
    {
        ICallbacks Callbacks { get; set; }
        string NameUC { get; set; }
        double Width { get; set; }
        double Height { get; set; }
        double Left { get; set; }
        double Top { get; set; }
        double ZoomFactorFromPluginModel { get; set; }
    }
    public interface ICallbacks
    {
        void SomeCallback();
    }
