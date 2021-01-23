    public void Print()
    {
        foreach (PropertyInfo prop in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            object value = prop.GetValue(this, new object[] { });
            Console.WriteLine("{0} = {1}", prop.Name, value);
        }
    }
