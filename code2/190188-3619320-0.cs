    static DefaultFields
    {
        private readonly string IniPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "defaultFields.ini");
        private readonly IniConfigSource Ini = GetIni();               
    
        private static DefaultFields _default;
        
        public static DefaultFields Default 
        { 
            get { if(this._default == null){ this._default = new DefaultFields(); } return this._default; } 
        }
        
        private DefaultFields()
        {
        }
        /// <summary>
        /// Creates a reference to the ini file on startup
        /// </summary>
        private IniConfigSource GetIni()
        {
            // Create Ini File if it does not exist
            if (!File.Exists(IniPath))
            {
                using (FileStream stream = new FileStream(IniPath, FileMode.CreateNew))
                {
                    var iniConfig = new IniConfigSource(stream);
                    iniConfig.AddConfig("default");
                    iniConfig.Save(IniPath);
                }
            }
    
            var source = new IniConfigSource(IniPath);
            return source;
        }
    
        public IConfig Get()
        {
            return Ini.Configs["default"];
        }
    
        public void Remove(string key)
        {
            Get().Remove(key);
            Ini.Save();
        }
    
        public void Set(string key, string value)
        {
            Get().Set(key, value ?? "");
            Ini.Save();
        }
    }
