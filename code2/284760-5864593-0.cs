    [Serializable()]
    class CustomDataStore
    {
        public CustomDataStore()
        {
            //This is required by serialization
        }
        private List<CustomDataStoreItem> _items;
        public List<CustomDataStoreItem> Items
        {
            get
            {
                if (_items == null)
                    _items = new List<CustomDataStoreItem>();
                return _items;
            }
            set { _items = value; }
        }
        public void LoadSettings(string SettingsFileName)
        {
            if (File.Exists(SettingsFileName))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead(SettingsFileName);
                CustomDataStore ds = (CustomDataStore)bf.Deserialize(fs);
                fs.Close();
                _items = ds.Items;
            }
        }
        public void SaveSettings(string SettingsFileName)
        {
            if (File.Exists(SettingsFileName))
                File.Delete(SettingsFileName);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Create(SettingsFileName);
            bf.Serialize(fs, this);
            fs.Close();
        }
    }
    [Serializable()]
    class CustomDataStoreItem
    {
        public CustomDataStoreItem()
        {
            //This is required by serialization
        }
        public string Type { get; set; }
        public string String1 { get; set; }
        public string String2 { get; set; }
    }
