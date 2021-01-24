    public void TestExtension() {
        //Arrange
        string expected = "Fake result";
        var fakedInnerClasses = Isolate.Fake.AllInstances<InnerClass>();
        Isolate.WhenCalled(() => fakedInnerClasses.GetDescription())
            .WillReturn(expected);
    
        var subject = new OuterClass();
    
        //Act
        subject.DoSthWithExtension();
        
        
        //Assert
        //...
    }
