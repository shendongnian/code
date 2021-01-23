        [TestMethod]
        public void MongodbTest()
        {
            var mongoServer = MongoServer.Create("mongodb://localhost:27020");
            var database = mongoServer.GetDatabase("StackoverflowExamples");
            var levels = database.GetCollection("levels");
            var level1 = new Level1();
            
            var nested1 = new LevelX() { Name = "Nested1" };
            var nested2 = new LevelX() { Name = "Nested2" };
            nested1.NestedLevels.Add(nested2);
            var nested3 = new LevelX() { Name = "Nested3" };
            nested2.NestedLevels.Add(nested3);
            level1.NestedLevels.Add(nested1);
            levels.Insert(level1);
            var item = levels.FindOneAs<Level1>();
            item.NestedLevels[0].NestedLevels[0].NestedLevels[0].Name = 
                                             "Changed nested level 3 name";
            levels.Save(item);
            var itemAfterUpdate = levels.FindOneAs<Level1>();
            Assert.AreEqual("Changed nested level 3 name", 
                itemAfterUpdate.NestedLevels[0].NestedLevels[0].NestedLevels[0].Name);
            levels.RemoveAll();
        }
