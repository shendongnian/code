    public class MySession
    {
        ...
        public T GetValue<T>(string key, T defaultValue)
        {
            return _sessionVars.ContainsKey(key) ? this._sessionVars[key] as T : defaultValue;
        }
    }
