    public class UnitTest
    {
      public void TestDecorator()
      {
        IDecorated mockOfIDecorated = new DecoratedMock();
        DecoratorBase decoratorBaseTest = new DecoratorBaseTest(mockOfIDecorated);
        // Use decoratorBaseTest instance to test its public members
      }
    }
