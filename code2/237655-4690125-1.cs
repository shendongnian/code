    GridView1.DataSource = new List<TestProduct> 
            {
                new TestProduct
                {
                    Name = "Test",
                    ID = "1",
                    Suppliers = new List<TestSupplier>
                    {
                        new TestSupplier {  Name="Supplier1" },
                        new TestSupplier { Name = "Supplier2" },
                        new TestSupplier { Name =" A very long supplier name"}
                    }
                }
            };
    
            GridView1.DataBind();
