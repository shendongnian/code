    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<CustomerOrder> orders = new List<CustomerOrder>();
                List<OrderError> orderErrors = new List<OrderError>();
                Dictionary<string, OrderError> dictOrderErrors = orderErrors
                    .GroupBy(x => x.OrderId, y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                foreach (CustomerOrder order in orders)
                {
                    order.ErrorMessage = dictOrderErrors[order.OrderId].ErrorMessage;
                }
            }
        }
        public class CustomerOrder
        {
            public string OrderId { get; set; }
            public string OrderStatus { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class OrderError
        {
            public string OrderId { get; set; }
            public string ErrorMessage { get; set; }
        }
    }
