      [Test]
      public void MockAGenericInterface()
      {
        IList<int> list = MockRepository.GenerateMock<IList<int>>();
        Assert.IsNotNull(list);
        list.Expect (x => x.Count).Return(5);
        Assert.AreEqual(5, list.Count); 
        list.VerifyAllExpectations();
      }
