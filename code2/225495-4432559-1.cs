Prod-Code:
...
public override IRenderable GetRenderable()
{
  var val = SomeCalculationUsingClassMemberVariables();
  return createEquationRenderable();
} 
public IRenderable createEquationRenderable() 
{
   return new EquationRenderable(val);
}
Test Case:
...
class Stubbed : SUT 
{
   boolean called = false;
   public override EquationRenderable createEquationRenderable() 
   {
      called=true;
      return MyMock();
   }
}
[Test]
public void test_new()
{
  Stubbed sut = new Stubbed();
  sut.GetRenderable();
  assertTrue(sut.called);
  // do further stuff on MyMock
}
