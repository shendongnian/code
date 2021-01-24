    var items = new List<Role>();
                items.Add(new Role() { Id = 1 , Name = "Admin" });
                var username = "test";
                var newOvj = new { username = username, roles = items };
                var stringdata = Newtonsoft.Json.JsonConvert.SerializeObject(newOvj);
