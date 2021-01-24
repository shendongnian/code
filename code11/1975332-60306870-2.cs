    [HttpGet]
           public async Task<string> ShowProductsAsync()
           {
                MongodbModel model = new MongodbModel();
                var products = await model.getAllProducts();
                Console.WriteLine(products);
                return JsonConvert.SerializeObject(products);
            }
