        [Fact]
        public void UpdateAccount_WithUpdateExecutorThrowingAnException_ExceptionThrown()
        {
            //Assign
            var context = new XrmFakedContext
            {
                ProxyTypesAssembly = Assembly.GetAssembly(typeof(Account))
            };
            var account = new Account() { Id = new Guid("e7efd527-fd12-48d2-9eae-875a61316639"), Name = "Faked Name" };
            context.Initialize(new List<Entity>() { account });
            context.AddFakeMessageExecutor<UpdateRequest>(new FakeUpdateRequestExecutor());
            var service = context.GetOrganizationService();
            //Act
            //Assert
            Assert.Throws<InvalidPluginExecutionException>(() => context.ExecuteCodeActivity<RandomCodeActivity>(account));
        }
