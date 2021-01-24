    [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        Product GetProduct(int ID);
        public Product GetProduct(int ID)
        {
            TestStoreEntities entities = new TestStoreEntities();
            return entities.Products.FirstOrDefault(x => x.Id == ID);
        }
