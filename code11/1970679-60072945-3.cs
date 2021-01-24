    using MongoDB.Driver;
    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    using System;
    using System.Linq;
    namespace StackOverFlow
    {
        public enum OrderStatus
        {
            AssignedToPickup,
            Stored,
            Initiated,
            OnHold,
            Excluded
        }
        public class OrderInfo : Entity
        {
            public Product[] Products { get; set; }
            public OrderStatus Status { get; set; }
        }
        public class Product
        {
            public Guid Id { get; set; }
        }
        public static class Program
        {
            private static void Main()
            {
                new DB("test-db");
                var productIDs = new[] { Guid.NewGuid(), Guid.NewGuid() };
                var orders = new[] {
                    new OrderInfo {
                        Status = OrderStatus.Excluded,
                        Products = new[] { new Product { Id = productIDs[0] } } },
                    new OrderInfo {
                        Status = OrderStatus.Initiated,
                        Products = new[] { new Product { Id = productIDs[1] } } }
                };
                orders.Save();
                var products = DB.Fluent<OrderInfo>()
                                 .Match(f =>
                                        f.ElemMatch(o => o.Products,
                                                    p => productIDs.Contains(p.Id)) &
                                        f.Where(o => o.Status == OrderStatus.AssignedToPickup ||
                                                     o.Status == OrderStatus.Initiated ||
                                                     o.Status == OrderStatus.OnHold ||
                                                     o.Status == OrderStatus.Stored))
                                 .Unwind(o => o.Products)
                                 .ReplaceWith<Product>("$Products")
                                 .Match(p => productIDs.Contains(p.Id))
                                 .ToList();
            }
        }
    }
