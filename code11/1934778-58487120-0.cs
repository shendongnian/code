    List<User> result = uList.SelectMany(item => item.UserId
                                           .Split('.')
                                           .Select(singleUserId => new User
                                           {
                                               Name = item.Name,
                                               UserId = singleUserId,
                                               RollNo = item.RollNo
                                           })).ToList();
