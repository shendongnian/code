    [Test]
    public void TestDeleteCategoryAssociatedToTest()
    {
        // Arrange
        Category category = CategoryHelper.Create("category", Project1);
        User user;
        Test test1 = IssueHelper.Create(Project1, "summary1", "description1", user);
        test1.Category = category;
        try
        {
            // Act
            category.Delete(user);
            // Assert       
            Assert.Fail("The Delete method did not throw an exception.");
        }
        catch
        {
            Assert.IsNotNull(Category.Load(category.ID));
            Assert.IsNotNull(Test.Load(test1.ID).Category);
        }
    }
