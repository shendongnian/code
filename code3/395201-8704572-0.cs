**Update:** The following is a code sample showing how you can process a type and recursively get all the types contained within it. You can call it this way: List<Type> typesHere = GetTypes(myObject.GetType())
        public static List<Type> GetTypes(Type t)
        {
            List<Type> list = new List<Type>();
            if (t.IsPrimitive)
            {
                if (!list.Contains(t))
                    list.Add(t);
                return list;
            }
            else if (!t.Assembly.Equals(System.Reflection.Assembly.GetExecutingAssembly()))
            {
                //if the type is defined in another assembly then we will check its
                //generic parameters. This handles the List<Item> case.
                var genArgs = t.GetGenericArguments();
                if (genArgs != null)
                    foreach (Type genericArgumentType in genArgs)
                    {
                        if(!list.Contains(genericArgumentType))
                            list.AddRange(GetTypes(genericArgumentType));
                    }
                return list;
            }
            else
            {
                //get types of props and gen args
                var types = t.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Select(pi => pi.PropertyType).ToList();
                types.AddRange(t.GetGenericArguments());
                foreach (System.Type innerType in types)
                {
                    //get the object represented by the property to traverse the types in it.
                    if (!list.Contains(innerType))
                        list.Add(innerType);
                    else continue; //because the type has been already added and as thus its child types also has been already added.
                    var innerInnerTypes = GetTypes(innerType);
                    //add the types filtering duplicates
                    foreach (Type t1 in innerInnerTypes) //list.AddRange(innerTypes); //without filtering duplicates.
                        if (!list.Contains(t1))
                            list.Add(t1);
                }
                return list;
            }
        }
