        User defaultPublicUser = null;
            foreach (var newUserData in _configData.Users)
            {
                var newUser = new User(newSite, newUserData.FullName, newUserData.Login, newUserData.Password);
                var userRole = newSite.UserRoles.First(ur => ur.Name == newUserData.UserRoleName);
                if (newUserData.UserRoleName == "Public")
                {
                    defaultPublicUser = newUser;
                }
                newUser.UserRoles.Add(userRole);
                newUser.UserStatusType = _daoFactory.GetUserStatusTypeDao().GetById(UserStatusType.cActive);
                _daoFactory.GetUserDao().Save(newUser);
            }
            _daoFactory.GetUserDao().FlushChanges();
