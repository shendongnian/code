    DataContext.Configuration.ProxyCreationEnabled = false;
    JArray usersArray = JArray.FromObject(from users in DataContext.Users.AsEnumerable()
                                                     select new
                                                     {
                                                         users.ID,
                                                         users.Name
                                                     });
                JObject obj = new JObject(new JProperty("users", usersArray));
                Response.Write(obj);
