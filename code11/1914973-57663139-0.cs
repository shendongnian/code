C#
[OneTimeSetUp]
public void MyTests_OneTimeSetup()
{
  _action = x => { x.ReturnValue = new[] { 1, 2, 3 }; };
  _collection = MockRepository.GenerateStub<INumberCollection>();
  _collection.Stub(c => c.GetNumbers())
    .Repeat.Any()
    .Return(new[] {0, 0, 0})
    .WhenCalled(_action);
}
