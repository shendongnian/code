[Fact]
public void ItReturnsTheRightThing() {
    _mockObject = new Mock<IMyInterface>();
   _mockObject.SetUp(o => o.FunctionIWantToMock()).Returns(new SpecialObject(true));
   var classIWantToTest = new ClassIWantToTest(_mockObject.Object);
   classIWantToTest.RunCode();
  ...
}
Try this and if it works, something interferes with the mock object in between 
