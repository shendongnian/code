      private void AddDataToRepository()
      {
           var testUser = new User{ UserId = 1, UserName = "Me" };
           var customers = new List<Customer>()
           {
                new Customer{Id = Guid.NewGuid().ToString(), Name = "ABC", Status = "active", Parent_id = _parentId, User = testUser},
                new Customer{Id = Guid.NewGuid().ToString(), Name = "DEF", Status = "canceled", Parent_id = _parentId, User = testUser},
                new Customer{Id = Guid.NewGuid().ToString(), Name = "HIJ", Status = "active", Parent_id = _parentId, User = testUser},
                new Customer{Id = Guid.NewGuid().ToString(), Name = "MNO", Status = "suspended", Parent_id = _parentId, User = testUser},
                new Customer{Id = Guid.NewGuid().ToString(), Name = "QRS", Status = "active", Parent_id = _parentId, User = testUser},
           };
           _customerRepositoryMock.Setup(x => x.Get()).Returns(customers.AsQueryable());
     }
