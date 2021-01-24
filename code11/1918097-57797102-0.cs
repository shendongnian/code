    private bool IsItemsExist(Action<IMappingOperationOptions> a, Func<IDictionary<string, object>, bool> itemsChecker)
    {
        // Create mock of options
        var optionsMock = new Mock<IMappingOperationOptions>();
        var itemsDictionary = new Dictionary<string, object>();
        optionsMock.SetupGet(o => o.Items).Returns(itemsDictionary);
        // Call action
        a(optionsMock.Object);
        // Call check function
        return itemsChecker(itemsDictionary);
    }
