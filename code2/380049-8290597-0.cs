    [Test]
    public void initializeRegistersViewDataWithGivenName()
    {
      ShuntedYourClass yourClass = new ShuntedYourClass();
      yourClass.initialize( /* arg list */ );
      
      // Verify 'Notify' was called
      Assert.NotNull(yourClass.registeredViewData);
      // Verify 'GetName' private method was invoked and
      // 'Name' was properly populated
      Assert.AreEqual("expected name", yourClass.registeredViewData.Name);
    }
    // Nested class for testing purposes only.
    class ShuntedYourClass : public YourClass
    {
      public ViewData registeredViewData;
      public override void Notify(ViewData vd)
      {
        this.registeredViewData = vd;
      }
    }
This code now verifies that the Initialize method does indeed work properly and executes the Notify with the proper parameters.
