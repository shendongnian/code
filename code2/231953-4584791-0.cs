    public class SettingsType {}
    public class Settings
    {
        private Thread _worker;
        public void SaveSettings(SettingsType type)
        {
            // save logic
        }
        public void BeginSaveSettings(SettingsType type)
        {
            _worker = new Thread(() => SaveSettings(type)) {IsBackground = true};
            _worker.Start();
        }
        public bool EndSaveSettings(TimeSpan timeOut)
        {
            return _worker.Join(timeOut);
        }
    }
    
