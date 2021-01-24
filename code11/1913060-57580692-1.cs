    [Fact]
    public void Should_Test_Something() {
        using (var mock = AutoMock.GetLoose()) {
            //Arrange
            IWorkflow workflow = mock.Create<Workflow>(); //<-- note asking for actual class
            //Act
            var result = workflow.DoSomething();
            //Assert
            // ...assert expected behavior            
        }
    }
