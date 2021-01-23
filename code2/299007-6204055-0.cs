    public void CheckMembers(object o)
    {
        foreach(var member in o.GetType().GetFields())
        {
            object value = member.GetValue(o);
        }
    }
