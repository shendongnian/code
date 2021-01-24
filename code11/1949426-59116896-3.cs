     var list1 = new List<ProductInventoryInfo>
            {
                new ProductInventoryInfo{ ProductName="Product 1"},
                new ProductInventoryInfo{ ProductName="Product 2"},
                new ProductInventoryInfo{ ProductName="Product 3"},
                new ProductInventoryInfo{ ProductName="Product 4"},
            };
     var list2 = new List<ProductInventoryInfo>
            {
                new ProductInventoryInfo{ ProductName="Product 2"},
            };
     var list3 = list1.Where(x => !list2.ObjectsAreEqual(x)).ToList(); //use Extensions Method
     //use override Equals
     var list4 = new List<ProductInventoryInfo>();
     list1.ForEach(x =>
         {
           list2.ForEach(y =>
              { 
                if (!x.Equals(y))
                  {
                     list4.Add(x);
                  }
              });
          });
