    [ImportMany(AllowRecomposition=true)]
    public IEnumerable<IBuilder> Builders{get; set;}
    public SomeClass()
    {
        // Load all builders from a MEF CompositionContainer
    }
    public void Build(User user)
    {
        var builder = Builders.FirstOrDefault(b => b.CanHandleUserType(user.UserType));
    
        if(builder == null)
        {
            throw new Exception("No UserType set");
        }else{
            builder.BuildTree();
        }
    }
