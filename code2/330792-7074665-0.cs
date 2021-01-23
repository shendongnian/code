            For<User>().ConditionallyUse(config =>
                {
                    config.If(ctx => ctx.GetInstance<HttpContextBase>().User == null)
                        .ThenIt.Is.Type<User.None>();
                    config.TheDefault.Is.Type<User>();
                });
