    [TestMethod]
    public void TestMethod1()
    {
        //Arrange 
        var fake = Isolate.Fake.Instance<TestSubject>();
    
        //Act
        //Getting/Setting desired properties of TestSubject class 
    
        //Assert
        PropertyInfo[] propertyInfos =
            fake.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly |
                                            BindingFlags.SetProperty);
    
        foreach (var propertyInfo in propertyInfos)
        {
            Isolate.Verify.WasCalledWithAnyArguments(() => propertyInfo.GetValue(fake, null));
        }
    
    }
