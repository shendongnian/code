    public static void ReflectionTest()
    {
        PropertyInfo[] properties = typeof(TestClass).GetProperties();
        for (int i = 0; i < 10000000; i++)
        {
            TestClass testClass = new TestClass();
            foreach (var propertyInfo in properties)
            {
                propertyInfo.SetValue(testClass, propertyInfo.Name + i);
            }
            TestClasses.Add(testClass);
        }
    }
