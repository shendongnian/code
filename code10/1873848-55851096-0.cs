    public T GetIntSetting<T>(string setting, int nullState) where T : System.Enum
    {
        var val = int.TryParse(GetStringSetting(setting, nullState.ToString()), out int parsed) ? parsed : nullState;
    	if (Enum.IsDefined(typeof(T), val))
    		return (T)val;
    	else
    		return (T)nullState;
    }
