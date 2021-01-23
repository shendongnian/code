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
            // Note how here we pretend we don't know TProp type
            var idBinder = CompileDataBinder<Person, object>("model.Id");
            object id = idBinder(model);
            Debug.Assert(id.Equals(123));
        }
        static Func<TModel, TProp> CompileDataBinder<TModel, TProp>(string expression)
        {
            var propNames = expression.Split('.');
            var model = Expression.Parameter(typeof(TModel), "model");
            Expression body = model;
            foreach (string propName in propNames.Skip(1))
                body = Expression.Property(body, propName);
            //Debug.WriteLine(prop);
            if (body.Type != typeof(TProp))
                body = Expression.Convert(body, typeof(TProp));
            Func<TModel, TProp> func = Expression.Lambda<Func<TModel, TProp>>(body, model).Compile();
            //TODO: cache funcs
            return func;
        }
    }
