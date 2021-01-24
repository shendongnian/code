    Mocker.Mock<IToTest>
       .Verify(x => x.MethodToTest(
           It.Is<object>(
               obj => 
                   obj.GetType().GetProperty("PropertyOne") != null &&
                   obj.GetType().GetProperty("PropertyOne").GetValue(obj).ToString() == "Test"
           )),
           Times.Once());
