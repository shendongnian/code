        int someFunction(Element instance, string propertyName)
        {
            MethodInfo prop = typeof(Element).GetProperty(propertyName).GetGetMethod();
            if (prop.ReturnType != typeof(int))
            {
                throw new Exception("Type of property does not match expected type of int");
            }
            return (int)prop.Invoke(instance, null);
        }
