    [TestClass]
    public class GlobalStoreTest
    {
        [TestMethod]
        public void GlobalStore_Test()
        {
            //Arrange
            var globalStore = new GlobalStore();
            globalStore.SetCache(new List<ClientModel>
            {
                new ClientModel
                {
                    ClientId = 1,
                    ClientName = "Client1"
                },
                new ClientModel
                {
                    ClientId = 2,
                    ClientName = "Client2"
                }
            });
            //Act
            var clients = globalStore.GetFromCache<ClientModel>();
            //Assert
            Assert.AreEqual(2, clients.Count());
        }
    }
