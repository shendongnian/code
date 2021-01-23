        [Test]
       public void Test()
        {
            var collection = Read.Database.GetCollection("test");
    
            var user = new User
            {
                Name = "Sam",
                Addresses = (new Address[] { new Address { House = "BIGHOUSE", Street = "BIGSTREET", _id = ObjectId.GenerateNewId().ToString() } })
            };
    
            collection.Insert(user.ToBsonDocument());
        }
