    foreach (var principal in gp.Members)
    {
        Type type = principal.GetType();
        if(type == typeof(UserPrincipal))
        {
          ...
        }
        else if(type == typeof(GroupPrincipal))
        {
         .....
        }
    }
