    private Action actiondelegate = (Action)(() => {});
    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        if (binder.Name == "OnMyEvent")
        {
            result = actiondelegate;
            return true;
        }
    }
