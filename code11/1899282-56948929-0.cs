    var serializer = new XmlSerializer(model.GetType());
            serializer.Serialize(sw, model);
            JObject o1 = JObject.Parse(@"{
             'FirstName': 'John',
             'LastName': 'Smith',
             'Enabled': false,
             'Roles': [ 'User' ]
              }");
            JObject o2 = JObject.Parse(@"{
             'Enabled': true,
             'Roles': [ 'User', 'Admin' ]
              }");
            o1.Merge(o2, new JsonMergeSettings
            {
                // union array values together to avoid duplicates
                MergeArrayHandling = MergeArrayHandling.Union
            });
            string json = o1.ToString();
            // {
            //   "FirstName": "John",
            //   "LastName": "Smith",
            //   "Enabled": true,
            //   "Roles": [
            //     "User",
            //     "Admin"
            //   ]
            // }
