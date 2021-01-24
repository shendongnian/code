    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace StackOrderProcessor
    {
    
        public class CustomersOrder
        {
            public OrderDto Order { get; set; }
            public  List<CustomersOrder> CustomersOrders = new List<CustomersOrder>();
            public DateTime OrderDate { get; set; }
            public string OrderStatus { get; set; }
            public int CustomerID { get; set; }
            public int Code { get; set; }
            public int ID { get;  set; }
        }
    
        public class Customer
        {
            public OrderDto Order { get; set; }
            public  List<Customer> Customers = new List<Customer>();
            public int Code { get; set; }
            public int ID { get; set; }
    
        }
        public class OrderDto
        {
            public DateTime OrderDate   { get; set; }
           
            public int CustomerCode { get; set; }
            public string OrderStatus { get; set; }
            public int Code { get; set; }
    
        }
    
        public interface IRepository
        {
            int GetOldCustomerId(int customerCode);
            int GetOldOrderId(int orderCode);
            void SaveCustomer(Customer customer);
            void SaveOrder(CustomersOrder order);
        }
       
    
        public class Repository : IRepository
        {
            private readonly Customer _cust;
            private readonly CustomersOrder _custOrder;
    
            public Repository(Customer cust, CustomersOrder custOrder )
            {
                _cust = cust;
                _custOrder = custOrder;
            }
           
            public int GetOldCustomerId(int customerCode)
            {
                
                var cuId = _cust.Customers.First(e => e.Code == customerCode);
                return cuId.ID;
            }
    
            public int GetOldOrderId(int orderCode)
            {
                var oId = _custOrder.CustomersOrders.FirstOrDefault(e => e.Code == orderCode);
                return oId.ID;
            }
    
            public void SaveCustomer(Customer customer)
            {
                
                _cust.Customers.Add(customer);
    
            }
    
            public void SaveOrder(CustomersOrder order)
            {
                _custOrder.CustomersOrders.Add(order);
            }
        }
    
        public class OrderProcess
        {
            private readonly IRepository _repository;
    
            public OrderProcess(IRepository repository)
            {
                _repository = repository;
            }
    
            public void Process(CustomersOrder order)
            {
                var oldOrder = _repository.GetOldOrderId(order.Code);
                if (oldOrder == 0)
                    _repository.SaveOrder(order);
            }
        }
    
        public class OrderBuilder
        {
            private readonly IRepository _repository;
    
            public OrderBuilder(IRepository repository)
            {
                _repository = repository;
            }
    
            public CustomersOrder OrderBuild(OrderDto dto)
            {
              
                var oldCustomerId = _repository.GetOldCustomerId(dto.CustomerCode);
                return new CustomersOrder()
                {
                    Order = dto,
                    OrderDate = Convert.ToDateTime(dto.OrderDate),
                    OrderStatus = dto.OrderStatus,
                    ID = oldCustomerId,
                    CustomerID = oldCustomerId,
    
                    Code = dto.Code
                };
            }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                var cust = new Customer();
                var custOrder = new CustomersOrder();
    
                #region PopulatingCustomer
                //Populating OrderDto
                var dto1 = new OrderDto { Code = 1, CustomerCode = 1, OrderDate = DateTime.Now.Date, OrderStatus = "OK" };
                //Populating Customer
                var customerList = cust.Customers = new List<Customer>();
                var customerOrderList = custOrder.CustomersOrders = new List<CustomersOrder>();
    
                var customer1 = new Customer
                {
                    Code = 1,
                    ID = 1, Order=dto1
                };
                var customer2 = new Customer
                {
                    Code = 2,
                    ID = 2,
                    
                };
                
                customerList.Add(customer1);
                customerList.Add(customer2);
                #endregion
    
                #region PopulatingCustomerOrder
               
                var customersOrder1 = new CustomersOrder { Code = 1, CustomerID = 1, ID = 1, Order = dto1, OrderDate = dto1.OrderDate, OrderStatus = dto1.OrderStatus };
                customerOrderList.Add(customersOrder1);
                #endregion
    
                #region InvokingMethods
                //IRepository
                IRepository IRepo = new Repository(cust,custOrder);
    
                //OrderProcessor
                var orderProcesor = new OrderProcess(IRepo);
               
                //OrderBuilder
                var dto2 = new OrderDto { Code = 2, CustomerCode = 2, OrderDate = DateTime.Now.Date, OrderStatus = "OK" };
                var oBuilder = new OrderBuilder(IRepo);
               var newCustOrder =  oBuilder.OrderBuild(dto2);
                customerOrderList.Add(newCustOrder);
                #endregion
                Console.Read();
    
            }
        }
    }
