    [Test]
    public void Add_AddTwoItems_ItemsGetsConsecutiveIds() {
        var customItem1 = new Mock<ICustomItem>();
        var customItem2 = new Mock<ICustomItem>();
        var cutomCollection = new CustomCollection<ICustomItem>();
        cutomCollection.Add(customItem1);
        cutomCollection.Add(customItem2);
		customItem1.VerifySet(x => x.Id = 1);
		customItem1.VerifySet(x => x.Id = 2);
    }
