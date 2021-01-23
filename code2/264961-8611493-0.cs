     var Users = from m in db.Users
                    join m2 in db.MyProfiles on m.UserId equals m2.UserId
                    where m.UserName == SearchUserName.UserName
                    select new UserViewModel
                    {
                        UserName = m.UserName,
                        LastActivityDate = m.LastActivityDate,
                        Address = m2.Address,
                        City = m2.City,
                        State = m2.State,
                        Zip = m2.Zip
                    };
