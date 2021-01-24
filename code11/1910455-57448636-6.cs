    public class DecoratorBaseTest : DecoratorBase
    {
      public DecoratorBaseTest(IDecorated mockOfIDecorated) : base(mockOfIDecorated) { /* ... */ }
    
      #region Overrides of DecoratorBase
    
      protected override void DoSomethingToExtendTheDecoratedBehavior()
      {
        // Do nothing here because the unit test 
        // tests only public members of DecoratorBase 
      }
    
      #endregion
    }
