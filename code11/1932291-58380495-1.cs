    //Arrange
    IClass iClass = A.Fake<IClass>();
    A.CallTo(() => iClass.Func(A<ObjParam>._))
        .Invokes((ObjParam arg) => arg.SomeIntValue += 1);
    var objParam = new ObjParam();
    objParam.SomeIntValue = 0;
    //Act
    iClass.Func(objParam);
    //Assert
    objParam.SomeIntValue.Should().Be(1);
