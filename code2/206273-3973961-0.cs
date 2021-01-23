    [TestMethod]
    public void CanDeserializeComplicatedObject()
    {
        var entry = new BlogEntry
        {
            ID = "0001",
            ContributorName = "Joe",
            CreatedDate = System.DateTime.UtcNow.ToString(),
            Title = "Stackoverflow test",
            Description = "A test blog post"
        };
        string json = JsonConvert.SerializeObject(entry);
        var outObject = JsonConvert.DeserializeObject<BlogEntry>(json);
        Assert.AreEqual(entry.ID, outObject.ID);
        Assert.AreEqual(entry.ContributorName, outObject.ContributorName);
        Assert.AreEqual(entry.CreatedDate, outObject.CreatedDate);
        Assert.AreEqual(entry.Title, outObject.Title);
        Assert.AreEqual(entry.Description, outObject.Description);
    }
