    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class FilterFieldAttribute: Attribute
    {
        public static T Clone<T>(T obj) where T : class, new()
        {
            return Cache<T>.clone(obj);
        }
        private static class Cache<T> where T : class, new()
        {
            public static readonly Func<T,T> clone;
            static Cache()
            {
                var param = Expression.Parameter(typeof(T), "source");
                var members = from prop in typeof(T).GetProperties()
                              where Attribute.IsDefined(prop, typeof(FilterFieldAttribute))
                              select Expression.Bind(prop, Expression.Property(param, prop));
    
                var newObj = Expression.MemberInit(Expression.New(typeof(T)), members);
                clone = Expression.Lambda<Func<T,T>>(newObj, param).Compile();
            }
        }
    } 
    
    public class OrdersViewModel 
    {
        [FilterField]
        [DisplayName("Order Number:")]
        public string OrderNumber { get; set; }
    
        [FilterField]
        [DisplayName("From date:")]
        public DateTime FromDate { get; set; }
    
        [FilterField]
        [DisplayName("To date:")]
        public DateTime ToDate { get; set; }
    
        [DisplayName("Status:")]
        public int Status { get; set; }
    
        static void Main()
        {
            var foo = new OrdersViewModel { OrderNumber = "abc", FromDate = DateTime.Now,
                ToDate = DateTime.Now, Status = 1};
            var bar = FilterFieldAttribute.Clone(foo);
        }
    } 
