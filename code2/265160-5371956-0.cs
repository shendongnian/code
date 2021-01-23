    public int PlaceOrder(int orderNumber)
        {
            using (UnitOfWork.Start())
            {           
                repository.SaveOrder(order)
    
                repository.SaveOrderStatus(order,"Order placed")
            }
        }
