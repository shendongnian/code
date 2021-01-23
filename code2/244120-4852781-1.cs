    [Test]
    public void ShouldNotNotifyListenersWhenPropertiesAreNotChanged()
    {
        var propertiesChanged = new List<string>();
        ViewModel = new CustomerViewModel();
        ViewModel.Firstname = "Test";
        ViewModel.PropertyChanged += (s, e) => propertiesChanged.Add(e.PropertyName);
        ViewModel.Firstname = "Test";
        Assert.AreEqual(0, propertiesChanged.Count); 
    }
