[TestMethod]
public void Test()
{
    var classToTest = new ClassToTest();
    classToTest.TheStub = MockRepository.GenerateMock<IStubbedInterface>();
    classToTest.TheStub.Expect(
        x => x.DoSomethingWithList(new TestList<int>() { 1, 2 }));
    classToTest.Run();
    classToTest.TheStub.VerifyAllExpectations();
}
