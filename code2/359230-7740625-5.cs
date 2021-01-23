    private static readonly Dictionary<string, Form> _dict 
        = new Dictionary<string, Form>();
    public T CreateOrShow<T>(string formName) where T : Form, new()
    {
        Form f = null;
        if (!_dict.TryGetValue(formName, out f))
        {
            f = new T();
            _dict.Add(formName, f);
        }
        return (T)f;
    }
    public T CreateOrShow<T>(string formName, Func<T> ctor) where T : Form
    {
        Form f = null;
        if (!_dict.TryGetValue(formName, out f))
        {
            f = ctor();
            _dict.Add(formName, f);
        }
        return (T)f;
    }
