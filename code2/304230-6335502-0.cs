    public static void Save<TSetting>(IGetSetting<TSetting> saveMe)
      where TSetting : IHasID
    {
      TSetting setting = saveMe.GetSetting();
      SerializableDictionary<string, TSetting> states =
        GetStates<SerializableDictionary<string, TSetting>>();
      bool isKnown = states.ContainsKey(setting.ID);
      if (isKnown)
      {
        states[setting.ID] = setting;
      }
      else
      {
        states.Add(setting.ID, setting);
      }
      RadControlManager.SetStates<SerializableDictionary<string, TSetting>>(states);
    }
    
    
    interface IGetSetting<TSetting>
    {
      TSetting GetSetting();
    }
    
    interface IHasID
    {
      string ID {get;}
    }
    
    
    class RadSplitBar : IGetSetting<RadSplitBarSetting>
    
    class RadSplitBarSetting : IHasID
