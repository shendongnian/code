    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    class Person
    {
        public int Id { get; set; }
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
                Id = 123,
                FullName = new FullName
                {
                    FirstName = "Duncan",
                    LastName = "Smart",
                }
            };
            var nameBinder = CompileDataBinder<Person, string>("model.FullName.FirstName");
            string fname = nameBinder(model);
            Debug.Assert(fname == "Duncan");
            var idBinder = CompileDataBinder<Person, int>("model.Id");
            int id = idBinder(model);
            Debug.Assert(id == 123);
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
