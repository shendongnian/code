        [Test]
        public void TestDeleteCategoryAssociatedToTest()
        {
            Category category = CategoryHelper.Create("category", Project1);
            User user;
            Test test1 = IssueHelper.Create(Project1, "summary1", "description1", user);
            test1.Category = category;
            try {
                category.Delete(user);          
                Assert.Fail();
             }
             catch (Exception exc)
             {
                Assert.IsNotNull(Category.Load(category.ID));
                Assert.IsNotNull(Test.Load(test1.ID).Category);
             }
        }
