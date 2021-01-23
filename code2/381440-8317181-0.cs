    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
        //set the actual  property and do
        OnPropertyChanged(binder.Name);      
    }
