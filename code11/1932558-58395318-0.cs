    [Fact]
    public async Task Should_DeleteWithAlarmIdOne_WhenCalledWitParameterAlarmIdOne() {
        // Arrange
        var expectedAlarmId = 1;
        var alarmCode = new AlarmCode { AlarmId = expectedAlarmId };
        var alarmCodes = new List<AlarmCode>(alarmCode);
        
        var repo = new Mock<IAlarmCodeRepository>();
        //fake the desired functionality
        repo.Setup(_ => _.DeleteAsync(It.IsAny<ASpec<AlarmCode>>()))
            .ReturnsAsync((ASpec<AlarmCode> arg) => alarmCodes.Where(arg));
        //allow async flow
        repo.Setup(_ => _.SaveAsync()).ReturnsAsync(Task.CompletedTask); //assuming it it void (Task)
        
        var command = new DeleteAlarmCodesCommand() { AlarmId = expectedAlarmId };
                
        var commandHandler = new DeleteAlarmCodesCommandHandler(repo.Object);
        // Act
        var result = await commandHandler.Handle(command, default(CancellationToken));
        
       // Assert
       repo.Verify(x => x.DeleteAsync(It.Is<ASpec<AlarmCode>>(spec => alarmCodes.Any(spec))), Times.Once);
       repo.Verify(x => x.SaveAsync(), Times.Once);
    }
