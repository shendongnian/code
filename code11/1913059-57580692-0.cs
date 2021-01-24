    [Fact]
    public void Should_Test_Something()
    {
        using (var mock = AutoMock.GetLoose()) {
            using (IWorkflow workflow = mock.Create<Workflow>()) { //<-- note asking for actual class        
                var result = workflow.DoSomething();
                // ...
            }
        }
    }
