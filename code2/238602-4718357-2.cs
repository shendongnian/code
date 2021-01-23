    var products = new List<Product>()
                                   {
                                       new Product() {Date = DateTime.Now.AddMinutes(-30), ProductName = "TodayProduct"},
                                       new Product() {Date = DateTime.Now.AddDays(-1), ProductName = "YesteradayProduct"},
                                       new Product() {Date = DateTime.Now.AddDays(-25), ProductName = "LastMonthProduct"}
                                   };
                var todayProducts = ProductsHelper.GetProductsGroup(ProductGroupEnum.Today, products);
                var yesterdayProducts = ProductsHelper.GetProductsGroup(ProductGroupEnum.Yesterday, products);
