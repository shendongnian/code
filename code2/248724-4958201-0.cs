    public string Genero
    {
        get { return _genero; }
        set { _genero = string.IsNullOrEmpty(value) ? value : value.Trim(); }
    }
