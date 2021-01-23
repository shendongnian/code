    [TestMethod]
    public void Validate()
    {
        try
        {
            int.Parse("dfd");
        
            // Test fails if it makes it this far
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (Exception ex)
        {
            Assert.AreEqual("blah", ex.Message);
        }
    }
