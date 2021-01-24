    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Linq.Expressions;
    
    namespace Ef6Test
    {
        public class Product
        {
            public int ProductId { get; set; }
            public int LocationId { get; set; }
            public int PaymentMethodId { get; set; }
            
        }
    
        static class FilterExtensions
        {
            public static IQueryable<T> Where<T>(this IQueryable<T> q, Filter<T> filter)
            {
                return filter.ApplyTo(q);
            }
        }
        abstract class Filter<T>
        {
            public abstract IQueryable<T> ApplyTo(IQueryable<T> q);
        }
        class ProductFilter : Filter<Product>
        {
            public int? ProductId { get; set; }
            public int? LocationId { get; set; }
            public int? PaymentMethodId { get; set; }
    
            public override IQueryable<Product> ApplyTo(IQueryable<Product> q)
            {
                if (ProductId.HasValue)
                {
                    q = q.Where(p => p.ProductId == this.ProductId);
                }
                if (LocationId.HasValue)
                {
                    q = q.Where(p => p.LocationId == this.LocationId);
                }
                if (PaymentMethodId.HasValue)
                {
                    q = q.Where(p => p.PaymentMethodId == this.PaymentMethodId);
                }
                return q;
            }
        }
    
        class Db : DbContext
        {
    
            public virtual DbSet<Product> Products { get; set; }
            
    
            class Program
            {
    
    
                static void Main(string[] args)
                {
    
                    Database.SetInitializer(new DropCreateDatabaseAlways<Db>());
    
                    using (var db = new Db())
                    {
                        db.Database.Log = m => Console.WriteLine(m);
                        db.Database.Initialize(false);
    
    
                        var filter = new ProductFilter();
                        filter.LocationId = 2;
    
                        var q = db.Products.Where(filter);
                        
    
                        var sql = q.ToString();
                        Console.WriteLine(sql);
                    }
    
    
                    Console.WriteLine("Hit any key to exit");
                    Console.ReadKey();
                }
    
              
               
                
            }
        }
    }
