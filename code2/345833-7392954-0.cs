    void Update(BaseType obj)
    {
        obj.Name = "aaa";
        obj.PostalCode = "123556";
    }
    void Update(ChildType obj)
    {
        b.ExtraField = "extra";
        Update((BaseType)obj);
    }
