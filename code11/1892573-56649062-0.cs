    public async Task TaskToTest_OnFailGiveException() {
        //Arrange
        //...mock database and setup accordingly
        //eg: database.InsertOrUpdateInfo(...).ReturnsAsync(false);
        var info = new Info(database);
        //Act
        var ex = await Record.ExceptionAsync(() => info.TaskToTest());
        //Assert
        Assert.NotNull(ex);
        Assert.IsType<Exception>(ex);
    }
