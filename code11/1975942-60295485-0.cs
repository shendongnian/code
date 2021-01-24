    public class SettingBase
    {
         public SettingDerived()
         {
             _settingNamesWithValues.Add("BananaSetting", new object());
         }
        private Dictionairy<string, object> _settingNamesWithValues = new Dictionairy<string, object>();
        public Dictionairy<string, object>() SettingNamesWithValues
        {
             get
             { 
                return _settingNameWithValue;
             }
        }
    }
