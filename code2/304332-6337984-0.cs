    class FooBarOfT
    {
        public T FooBar<T>(Func<T> function)
        {
            T returnData = function();
            //Want to iterate through returnData to do something to it.
            if (returnData is IEnumerable) 
            {
                // get generic type argument
                var returnDataType = returnData.GetType();
                if (returnDataType.IsGenericType)
                {
                    // this is a System.Collections.Generic.IEnumerable<T> -- get the generic type argument to loop through it
                    Type genericArgument = returnDataType.GetGenericArguments()[0];
                    var genericEnumerator =
                        typeof(System.Collections.Generic.IEnumerable<>)
                            .MakeGenericType(genericArgument)
                            .GetMethod("GetEnumerator")
                            .Invoke(returnData, null);
                    IEnumerator enm = genericEnumerator as IEnumerator;
                    while (enm.MoveNext())
                    {
                        var item = enm.Current;
                        Console.WriteLine(string.Format("Type : {0}", item.GetType().Name));
                    }
                    
                }
                else
                {
                    // this is an System.Collections.IEnumerable (not generic)
                    foreach (var obj in (returnData as IEnumerable))
                    {
                        // do something with your object
                    }
                }
            }
            return returnData;
        }
    }
