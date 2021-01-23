    [TestMethod]
    public void MyViewModel_ModelRaisesValueChangedEvent_MyStringIsUpdated()
    {
        //Arrange.
        var modelStub = MockRepository.GenerateStub<MyModel>();
        MyViewModel viewModel = new MyViewModel(modelStub);
    
        //Act
        modelStub.Raise(
           x => x.ValueChanged += null,
           modelStub, // sender
           EventArgs.Empty);
    
        //Assert.
        Assert.AreEqual("Value has changed", viewModel.MyString);
    }
