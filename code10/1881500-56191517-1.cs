    public int GetIntSetting(ISetting setting, int nullState)
    {
        int.Parse(GetStringSetting(setting, nullState.ToString()), out int parsed);
        if(parsed == nullState) 
        {
             UpdateIntSetting(setting, nullState);
        }
        
        return parsed;
    }
