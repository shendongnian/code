    namespace MvcApp.Models
    {
        public class MyAppContextInitializer : DropAndCreateAlways<MyAppContext>
        {
            protected override void Seed(MyAppContext context)
            {
                Product product = new Product
                {
                    Name = "Widget",
                    Price = 10.00m;
                    Description = "It's a widget!"
                };
                context.Products.Add(product);
                base.seed(context);
            }
            
        }
    }
