    public class SettingDerived : SettingBase
    {
         public SettingDerived()
         {
             _settingNamesWithValues.Add("DerivedBananaSetting", new object());
         }
         private Dictionairy<string, object> _settingNamesWithValues = new Dictionairy<string, object>(); 
         //Hide the base SettingNamesWithValues, as we add the values to the derived collection anyways
         public new Dictionairy<string, object>() SettingNamesWithValues
         {
             get
             { 
                foreach(var keyValue in base.SettingNamesWithValues)
                {
                     _settingNameWithValue.Add(keyValue.Key, keyValue.Value);
                }                  
                return _settingNameWithValue;
             }
         }
    }
