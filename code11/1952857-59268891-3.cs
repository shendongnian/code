    public void InstantiateAllObjects()
    {
        foreach (FieldInfo field in this.GetType()
                                        .GetFields(BindingFlags.Public | BindingFlags.Instance)
                                        .Where(x => x.Name.Contains("Object")))
        {
            MyObject obj= new MyObject();
            obj.PropertyChanged += (s, e) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            field.SetValue(this, obj);
        }
    }
