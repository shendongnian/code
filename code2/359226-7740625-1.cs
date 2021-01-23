    private static readonly Dictionary<string, Form> _dict 
        = new Dictionary<string, Form>();
    public T CreateOrShow<T>(string formName) where T : Form
    {
        Form f = null;
        if (!_dict.TryGetValue(formName, out f))
        {
            f = new Form();
            _dict.Add(formName, f);
        }
        return (T)f;
    }
