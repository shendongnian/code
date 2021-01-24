    public class ClassMethod2BTested
    {  
       PracticeEntities4 _context; //declare the context
       public ClassMethod2BTested(PracticeEntities4 context) // inject the context
       {
          _context=context; // set the context to local variable
       }
       public CustomersOrder OrderBuild(OrderDto dto)
       {
            //using (var context = new PracticeEntities4()) // remove this
            {
                var oldStoreId = _context.Stores.FirstOrDefault(e => e.Code == dto.StoreCode).Id;
                var oldCustomerId = _context.Customers.FirstOrDefault(e => e.Code dto.CustomerCode).Id;
                return new CustomersOrder()
                {
                    OrderDate = Convert.ToDateTime(dto.OrderDate),
                    OrderStatus = dto.OrderStatus,
                    DeliveryDate = Convert.ToDateTime(dto.DeliveryDate),
                    CustomerId = oldCustomerId,
                    StoreId = oldStoreId,
                    Code = dto.Code
                };
            };
        }
    }
