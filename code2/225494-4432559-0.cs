Prod-Code:
...
public override IRenderable GetRenderable()
{
  var val = SomeCalculationUsingClassMemberVariables();
  return new EquationRenderable(val);
} 
Test Case:
...
[Test]
public void test_new()
{
  SUT sut = ...;
  IRenderable r = sut.GetRenderable();
  assertTrue(r instanceof EquationRenderable);
}
