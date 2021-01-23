    public static bobase GetByCriteria<T,TCriteria>(TCriteria myCriteria)
                where T : bobase
                where TCriteria : BaseCriteria
            {
                T myObject = default(T);
                Type[] myMethodTypes = new Type[]{typeof(string),typeof(int),typeof(TCriteria)};
                System.Reflection.MethodInfo myMethod = myObject.DBclass.GetMethod("GetByCriteria", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static, null, myMethodTypes, null);
                object[] myMethodParameters = new object[]{"someValueHere", 1, myObject};
                return (bobase)myMethod.Invoke(null, myMethodParameters);
            }
