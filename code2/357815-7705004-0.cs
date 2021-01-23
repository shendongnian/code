    public class CallItem
        {
            public int Id { get; set; }
            public float Discount { get; set; }
            public virtual Product Product { get; set; }
        }
     public class Product
        {
            public int Id { get; set; }
    
            public decimal BaseCost { get; set; }
            public int UnitSize { get; set; }
            public bool IsWasteOil { get; set; }
    
            public string Code { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Ingredients { get; set; }
        }
    using (var context = new StackOverFlowContext())
                {
                    var p = new Product
                                    {
                                        Id = 1,
                                        BaseCost = 200,
                                        Code = "Hola",
                                        Description = "Soe description",
                                        Ingredients = "Some  ingredients",
                                        IsWasteOil = true,
                                         Name = "My Product",
                                         UnitSize = 10
                                        
                                    };
    
                    var item = new CallItem
                                        {
                                            Id = 101,
                                            Discount = 10,
                                             Product = p
                                        };
                    context.CallItems.Add(item);
                    context.SaveChanges();
                    var result = from temp in context.CallItems
                                 select temp;
                    Console.WriteLine("CallItem Id"+result.First().Id);
                    Console.WriteLine("ProductId"+result.First().Product.Id);
                }
