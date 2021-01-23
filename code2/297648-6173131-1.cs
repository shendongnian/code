    var user = // get some user
    var dataContext = // your DB context
    const BindingFlags AllInstance = BindingFlags.Instance | BindingFlags.NonPublic
            | BindingFlags.Public;
    object commonDataServices = typeof(DataContext)
        .GetField("services", AllInstance)
        .GetValue(dataContext);
    object identifier = commonDataServices.GetType()
        .GetProperty("IdentityManager", AllInstance)
        .GetValue(commonDataServices, null);
    MethodInfo find = identifier.GetType().GetMethod("Find", AllInstance);
    var metaType = dataContext.Mapping.GetMetaType(typeof(User));
    object[] keys = new object[] { user.Id };
    var user2 = (User)find.Invoke(identifier, new object[] { metaType, keys });
    bool pass = ReferenceEquals(user, user2);
