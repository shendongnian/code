        public class OrderVM
        {
            public OrderVM() { 
              Bicycles = new List<BicycleVM>();
            }
            public OrderVM(OrderDTO row)
            {
                Id = row.Id;
                ClientId = row.ClientId;
                OrderDate = row.OrderDate;
                Bicycles = new List<BicycleVM>();
            }
