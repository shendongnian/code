        [Given(@"I have the following Children:")]
        public void GivenIHaveTheFollowingChildren(Table table)
        {
            ScenarioContext.Current.Set(table.CreateSet<ChildObject>());
        }
        [Given(@"I have entered the following MyObject:")]
        public void GivenIHaveEnteredTheFollowingMyObject(Table table)
        {
            var obj = table.CreateInstance<MyObject>();
            var children = ScenarioContext.Current.Get<IEnumerable<ChildObject>>();
            obj.Children = new List<ChildObject>();
            foreach (var row in table.Rows)
            {
                if(row["Field"].Equals("Children"))
                {
                    foreach (var childId in row["Value"].Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
                    {
                        obj.Children.Add(children
                            .Where(child => child.Id.Equals(Convert.ToInt32(childId)))
                            .First());
                    }
                }
            }
        }
