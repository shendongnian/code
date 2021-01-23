    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    class Person
    {
        public FullName FullName { get; set; }
    }
    class FullName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person model = new Person
            {
                FullName = new FullName
                {
                    FirstName = "Duncan",
                    LastName = "Smart"
                }
            };
            Func<Person, string> expr = CompileDataBinder<Person, string>("model.FullName.FirstName");
            string propertyName = expr(model);
            Debug.Assert(propertyName == "Duncan");
        }
        static Func<TModel, TProp> CompileDataBinder<TModel, TProp>(string expression)
        {
            var propNames = expression.Split('.');
            var model = Expression.Parameter(typeof(TModel), "model");
            Expression getprop = model;
            foreach (string propName in propNames.Skip(1))
                getprop = Expression.Property(getprop, propName);
            //Debug.WriteLine(prop);
            return Expression.Lambda<Func<TModel, TProp>>(getprop, model).Compile();
        }
    }
