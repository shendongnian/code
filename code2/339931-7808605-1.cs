        [Test]
        public void CanSaveCustomersInParallel()
        {
            var service = new ServiceStub(new DummyRepository());
            var customers = new List<List<Customer>>
                                {
                                    new List<Customer>
                                        {
                                            new Customer {FirstName = "FirstName1"},
                                            new Customer {FirstName = "FirstName2"}
                                        },
                                    new List<Customer>
                                        {
                                            new Customer {FirstName = "FirstName3"},
                                            new Customer {FirstName = "FirstName4"}
                                        }
                                };
            service.ParallelSaveBatch(customers);
            Assert.AreEqual(service.Count, customers.Count);
        }
