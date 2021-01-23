        [Test]
        public void TestDeletionOnTransientObject()
        {
            NormalSalesFlowActivity normalSalesFlowActivity =
                Factories.SalesFlowActivityFactory.CreateNormalSalesFlowActivities(null, 
                opt => opt.NoOfEntities(1)).First();
            Assert.That(normalSalesFlowActivity.Id, Is.EqualTo(0));
            Session.Delete(normalSalesFlowActivity);
        }
