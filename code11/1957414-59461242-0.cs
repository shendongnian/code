        class Program
        {
            public static T GetById<T>(int? id)
            {
                var getByIdMethod = typeof(Program).GetMethod("GetById"); // get method definition
                object obj = Activator.CreateInstance(typeof(T));
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (prop.PropertyType.Namespace == "Entities")
                    {
                        int? idParent = n1; //where n1 is a value returned previously from DB
                        Type objType = prop.PropertyType;
                        var genericGetById = getByIdMethod.MakeGenericMethod(objType); //instantiate generic method with objType as generic parameter
                        prop.SetValue(obj, genericGetById.Invoke(null, new object[] { idParent })); // here you invoke the generic method instantiated above, passing null for instance (static method) and the actual method parameters as an object array
                    }
                    prop.SetValue(obj, n2); //where n2 is a value returned previously from DB
                }
                return (T)obj;
            }
    
            static void Main(string[] args)
            {
                GetById<Entities.Order>(1); // sample call 
            }
        }
