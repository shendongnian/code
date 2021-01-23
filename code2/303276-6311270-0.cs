    public interface ISetting<T1, T2>
    {
        void SetSettings(T1 obj);
        T2 GetSettings(T1 obj);
    }
    public class RadDockSettings : ISetting<RadDockSetting, CormantRadDock>
