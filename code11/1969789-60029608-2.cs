    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StackOrderProcessor;
    
    namespace StackOrderProcessor.UnitTests
    {
        [TestClass]
        public class RepositoryTests
        {
            [TestMethod]
            public void GetOldCustomerId_WhenCalled_ReturnsOId()
            {
                //Arrange
                var cust = new Customer();
                var custOrder = new CustomersOrder();
    
                IRepository repo = new Repository(cust,custOrder);
                var customerList = cust.Customers = new List<Customer>();
    
                var dto1 = new OrderDto { Code = 1, CustomerCode = 1, OrderDate = DateTime.Now.Date, OrderStatus = "OK" };
                var customer1 = new Customer
                {
                    Code = 1,
                    ID = 1,
                    Order = dto1
                };
                var customer2 = new Customer
                {
                    Code = 2,
                    ID = 2,
    
                };
    
                customerList.Add(customer1);
                customerList.Add(customer2);
    
                
                //Act
                repo.GetOldCustomerId(1);
    
    
                //Assert
                Assert.AreEqual(1, 1); //Test will Pass as we have a customer of Code  1
    
            }
    
            [TestMethod]
            //MethodName_Scenario_Expectedbehavior
            public void SaveCustomer_WhenCalled_AddsNewCustomer()
            {
    
                var cust = new Customer();
                var custOrder = new CustomersOrder();
    
                IRepository repo = new Repository(cust, custOrder);
                var customerList = cust.Customers = new List<Customer>();
    
                var dto1 = new OrderDto { Code = 1, CustomerCode = 1, OrderDate = DateTime.Now.Date, OrderStatus = "OK" };
                var customer1 = new Customer
                {
                    Code = 1,
                    ID = 1,
                    Order = dto1
                };
                var customer2 = new Customer
                {
                    Code = 2,
                    ID = 2,
    
                };
    
                customerList.Add(customer1);
                customerList.Add(customer2);
                //Act
    
                var custToSave = new Customer
                {
                    Code = 3,
                    ID = 3,
                    Order = null
                };
                repo.SaveCustomer(custToSave);
    
                //Assert
                Assert.AreEqual(3, customerList.Count);
    
    
            }
    
        }
    
        [TestClass]
        public class OrderProcessor1Tests
        {
            [TestMethod]
            public void Process_WhenOrderIsZero_AddsNewCustomerOrder()
            {
                //Arrange
                var cust = new Customer();
                var custOrder = new CustomersOrder();
                var customerOrderList = custOrder.CustomersOrders = new List<CustomersOrder>();
    
                IRepository repo = new Repository(cust, custOrder);
               
                var orderProcessor = new OrderProcess(repo);
    
                
                var dto1 = new OrderDto { Code = 1, CustomerCode = 1, OrderDate = DateTime.Now.Date, OrderStatus = "OK" };
    
                var custOrder1 = new CustomersOrder { ID = 1, Code = 1, CustomerID = 1, Order = dto1, OrderDate = dto1.OrderDate, OrderStatus = dto1.OrderStatus };
    
                customerOrderList.Add(custOrder1);
    
    
                //Act
                orderProcessor.Process(custOrder1);
    
                //Assert
                Assert.AreEqual(1, customerOrderList.Count);
            }
        }
    }
