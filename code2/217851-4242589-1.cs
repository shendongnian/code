        var FooPhoneUsers = 
            from
                f in Foos
            from
                pu in PhoneUsers.Where(pu => pu.Id = f.UserId)
            select
                new FooPhoneUser
                {
                    Foo = f,
                    User = pu
                };
