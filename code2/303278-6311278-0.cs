    public interface ISetting<T>
    {
        T Setting { get; set; }
    }
    
    public class RadDockSetting : ISetting<CormantRadDock>
    {
        public CormantRadDock Setting { get; set; }
    }
