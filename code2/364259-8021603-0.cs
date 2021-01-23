    using (var session = UnitOfWork.Begin())
                {
                    _userRepository.Use(session).Create(user);
                    _roleRepository.Use(session).AddToRole(user, Role.Public);
                    session.Commit();
                }
