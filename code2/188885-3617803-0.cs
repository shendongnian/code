    return new CompensableActivity()
    {
        Body = new Sequence()
        {
            Activities =
                {
                    new AuthenticateUserActivity()
                    {
                        Username = this.Username.In(),
                        Password = this.Password.In(),
                        Guid = this.Guid.Out(),
                        Result = this.ValidCredential.Out()
                    },
                    new If(this.ValidCredential.In())
                    {
                        Then = new GetUserRoleActivity()
                        {
                            Username = this.Username.In(),
                            Password = this.Password.In(),
                            Result = this.Role.Out()
                        },
                        Else = new Assign<ProvisioningRole>()
                        {
                            To = this.Role.Out(),
                            Value = ProvisioningRole.User
                        }
                    }
                }
        },
    };
