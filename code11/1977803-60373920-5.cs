    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    namespace CGS
    {
        class Program
        {
            static void Main()
            {
                var projects = new ExpandoObject() as IDictionary<string, Object>;
                object listObject1 = new
                {
                    ProjectURL = "string",
                    ListItemID = 1,
                    UserAdded  = true
                };
                projects.Add("Project" + 1, listObject1);
                object listObject2 = new
                {
                    ProjectURL = "string",
                    ListItemID = 2,
                    UserAdded  = true
                };
                projects.Add("Project" + 2, listObject2);
                object listObject3 = new
                {
                    ProjectURL = "string",
                    ListItemID = 3,
                    UserAdded  = false
                };
                projects.Add("Project" + 3, listObject3);
                foreach (var item in projects.Values)
                {
                    if (PropertiesOfType<bool>(item).Any(property => !property.Value))
                        Console.WriteLine($"{item} has a false bool.");
                }
            }
            public static IEnumerable<KeyValuePair<string, T>> PropertiesOfType<T>(object obj)
            {
                return from p in obj.GetType().GetProperties()
                    where p.PropertyType == typeof(T)
                    select new KeyValuePair<string, T>(p.Name, (T)p.GetValue(obj));
            }
        }
    }
