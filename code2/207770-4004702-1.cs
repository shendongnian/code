        t = DataSource.GetType();
        
        if (t.IsGenericType)
        {
            Type elementType = t.GetGenericArguments()[0];
            if (t.ToString() == string.Format("System.Collections.Generic.List`1[{0}]", elementType))
            {
                  //your code here
            }
        }
