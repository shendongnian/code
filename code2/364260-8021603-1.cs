    using (var session = UnitOfWork.Begin())
                {
                    session.Get<IUserRepository>().Create(user);
                    session.Get<IRoleRepository>().AddToRole(user, Role.Public);
                    session.Commit();
                }
