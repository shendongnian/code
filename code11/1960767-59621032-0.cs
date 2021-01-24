    for(var i = 1; i <= users.Count; i++)
                        {
                            User use = ctx.Web.EnsureUser(users[i].Mail);
                            gru.Users.AddUser(use);
                            if (i % 100 == 0)
                            {
                                ctx.ExecuteQuery();
                            }
                        }
