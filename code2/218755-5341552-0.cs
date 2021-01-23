        new public IPrincipal User
        { //we override User for impersonation
            get {
                if (/*check for impersonation*/)
                {
                    return /*impersonated*/;
                }
                else
                {
                    return base.User;
                }
            }
        }
