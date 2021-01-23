    //Arrange
    IJobProcess stub = MockRepository.GenerateStub<IJobProcess>();
    stub.Stub(x => x.CheckTeamMeetingInLastMonth(null)).IgnoreArguments().Return(true);
    stub.Stub(x => x.GetOutstandingActions(null)).IgnoreArguments().Return(
                    new List<ProjectActionsDomain.DomainObjects.ProjectAction>()
                    );   
    //Act
    -- Perform SUT --
    //Assert
    stub.AssertWasCalled(x => x.CheckTeamMeetingInLastMonth(someExpectedValue));
   
    
