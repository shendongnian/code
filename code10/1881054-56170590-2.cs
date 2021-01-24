    List<TestParent> parents = new List<TestParent>();
                TestChild child = new TestChild() { Name = "Test" };
                //add to parent class with the same child class;
                parents.Add(new TestParent() { Child = new List<TestChild>() { child } });
                parents.Add(new TestParent() { Child = new List<TestChild>() { child } });
                String data = JsonConvert.SerializeObject(parents);
                List<TestParent> deserializedData = JsonConvert.DeserializeObject<List<TestParent>>(data);
                var comparer = new ChildComparer();
                List<TestChild> brokenLinkCollection = deserializedData.SelectMany(x => x.Child).Distinct().ToList();
                // 2 Child with the same Name
                List<TestChild> uniqueCollection = deserializedData.SelectMany(x => x.Child).Distinct(comparer).ToList();
    
                var processedChild = deserializedData.Select(x => x.Child).ToList();
    
                processedChild.ForEach(x =>
                {
                    var substitutedCollection = uniqueCollection.Where( uc => x.Contains(uc, comparer)).ToList(); 
                    x.Clear();
                    x.AddRange(substitutedCollection);
                });
              
                List<TestChild> resoredCollection = deserializedData.SelectMany(x => x.Child).Distinct().ToList();
                // 1 Child is found due to linking to one memory object
