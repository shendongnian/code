    [TestMethod]
      public void CanGetPurchaseOrderByPurchaseOrderNumber()
     {
          _purchaseOrderMockRepository.Setup(s => s.Find(It.IsAny<Func<PurchaseOrder, bool>>()))
              .Returns((Func<PurchaseOrder, bool> expr) => new List<PurchaseOrder>() {FakeFactory.GetPurchaseOrder()});
          _purchaseOrderService.FindPurchaseOrderByOrderNumber("1111");
          _purchaseOrderMockRepository.VerifyAll();
     }
    
