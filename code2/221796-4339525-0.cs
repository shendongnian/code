    private Dictionary<string, Func<string>> m_map;
    public void AddValue(string key, string value) {
      m_map[key] = () => value;
    }
    public void AddValue(string key, Func<string> value) {
      m_map[key] = value;
    }
