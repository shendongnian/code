    private static readonly Dictionary<string, MyForm> _dict 
        = new Dictionary<string, MyForm>();
    public MyForm CreateOrShow(string formName)
    {
        Form f = null;
        if (!_dict.TryGetValue(formName, out f))
        {
            f = new MyForm();
            _dict.Add(formName, f);
        } 
        return f;
    }
