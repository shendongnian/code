            public class Section
            {
                public List<Group> groupList { get; set; }
            }
            public class Group
            {
                public List<Product> productList { get; set; }
                public int GroupID { get; set; }
                public string GroupName { get; set; }
            }
            public class Product
            {
                public int ProductID { get; set; }
                public string ProductName { get; set; }
                public string ProductDetails { get; set; }
            }
            Section section = new Section { groupList = new List<Group>() };
            Group group = new Group { GroupID = 1, GroupName = "Fruits", productList = new List<Product>() };
            Product product = new Product { ProductID = 1, ProductName = "Apples", ProductDetails = "On Sale" };
            group.productList.Add(product);
            product = new Product { ProductID = 2, ProductName = "Oranges", ProductDetails = "Not on Sale" };
            group.productList.Add(product);
            product = new Product { ProductID = 3, ProductName = "Pears", ProductDetails = "Big Spender Sale" };
            group.productList.Add(product);
            product = new Product { ProductID = 4, ProductName = "Grapes", ProductDetails = "Not on Sale" };
            group.productList.Add(product);
            section.groupList.Add(group);
            group = new Group { GroupID = 2, GroupName = "Vegetables", productList = new List<Product>() };
            product = new Product { ProductID = 5, ProductName = "Carrots", ProductDetails = "Not on Sale" };
            group.productList.Add(product);
            product = new Product { ProductID = 6, ProductName = "Celery", ProductDetails = "Last week only" };
            group.productList.Add(product);
            product = new Product { ProductID = 7, ProductName = "Eggplant", ProductDetails = "Big Spender Sale" };
            group.productList.Add(product);
            product = new Product { ProductID = 8, ProductName = "Oniones", ProductDetails = "N/A" };
            group.productList.Add(product);
            section.groupList.Add(group);
            group = new Group { GroupID = 3, GroupName = "Meat", productList = new List<Product>() };
            product = new Product { ProductID = 9, ProductName = "Beef", ProductDetails = "On Sale" };
            group.productList.Add(product);
            product = new Product { ProductID = 10, ProductName = "Pork", ProductDetails = "Back for two weeks" };
            group.productList.Add(product);
            product = new Product { ProductID = 11, ProductName = "Chicken", ProductDetails = "On sale" };
            group.productList.Add(product);
            product = new Product { ProductID = 12, ProductName = "Turkey", ProductDetails = "Going fast" };
            group.productList.Add(product);
            section.groupList.Add(group);
            listView.DataSource = section.groupList;
            listView.DataBind();
        }
        
