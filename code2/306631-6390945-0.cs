    public interface IPlugin
    {
        Form Host {get; set; }
        bool HookMethod(object sender,string methodName,params object[] parameters);
        bool HookAddCode(object sender,string hookName,params object[] parameters);
        void LaunchToolbarButton(long patNum);
    }
