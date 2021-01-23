    public virtual SessionSecurityToken ContextSessionSecurityToken
    {
        get
        {
            return (SessionSecurityToken) HttpContext.Current.Items[(object) typeof (SessionSecurityToken).AssemblyQualifiedName];
        }
        internal set
        {
            HttpContext.Current.Items[(object) typeof (SessionSecurityToken).AssemblyQualifiedName] = (object) value;
        }
    }
