    public class Product
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
    
    static void Main(string[] args)
    {
        List<Product> products = (from i in Enumerable.Range(1, 10)
                              select new Product { ID = i, Name = "product " + i, Date = DateTime.Now.AddDays(-i) }).ToList();  //the test case
        
        const string SortBy = "Date";  // to test you can change to "ID"/"Name"
        Type sortType = typeof(Product).GetProperty(SortBy).PropertyType;     // DateTime
        ParameterExpression sortParamExp = Expression.Parameter(typeof(Product), "p");    // {p}
        Expression sortBodyExp = Expression.PropertyOrField(sortParamExp, SortBy);   // {p.DateTime}
        LambdaExpression sortExp = Expression.Lambda(sortBodyExp, sortParamExp);   //   {p=>p.DateTime}
        var OrderByMethod = typeof(Enumerable).GetMethods().Where(m => m.Name.Equals("OrderBy") && m.GetParameters().Count() == 2).FirstOrDefault().MakeGenericMethod(typeof(Product), sortType);
        var result = OrderByMethod.Invoke(products, new object[] { products, sortExp.Compile() });
    }
