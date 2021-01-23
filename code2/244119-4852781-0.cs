    [Test]
    public void ShouldNotifyListenersWhenFirstNameChanges()
    {
        var propertiesChanged = new List<string>();
        ViewModel = new CustomerViewModel();
        ViewModel.PropertyChanged += (s, e) => propertiesChanged.Add(e.PropertyName);
        ViewModel.Firstname = "Test";
        Assert.Contains("Firstname", propertiesChanged);      
        Assert.AreEqual("Test", ViewModel.Firstname);  
    }
