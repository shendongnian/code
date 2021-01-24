    public object this[string key]
    {
        get
        {
            switch(key)
            {
                 case nameof(id): return id;
                 case nameof(full_name): return full_name;
                 case nameof(email): return email;
                 default: throw new ArgumentOutOfRangeException();
            }
        }      
        set
        {
            switch(key)
            {
                 case nameof(id):
                     id = value.ToString();
                     break;
                 case nameof(full_name):
                     full_name = value.ToString();
                     break;
                 case nameof(email):
                     email = value.ToString();
                     break;
                 default: throw new ArgumentOutOfRangeException();
            }
        }
    }
    public void Foo()
    {
        var row = new Row();
        row["id"] = "Foo";
    }
