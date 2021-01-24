       [Test]
        public void TestIncrement()
        {
            using (var context = new TestDbContext())
            {
                var newItem = new Assignee();
                context.Assignees.Add(newItem);
                context.SaveChanges();
            }
        }
