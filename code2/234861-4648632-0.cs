            [Test]
            public void AllOurPocosNeedToBeSerializable()
            {
                Assembly assembly = Assembly.GetAssembly(typeof (PutInPocoElementHere));
                int failingTypes = 0;
                foreach (var type in assembly.GetTypes())
                {
                    if(type.IsSubclassOf(typeof(Entity)))
                    {
                        if (!IsTypeSerializeable(type)) failingTypes++;
                    }
                }
                Assert.That(failingTypes, Is.EqualTo(0), string.Format("Look at console output for other types that need to be serializable. {0} in total ", failingTypes));
            }
    
    //what is used above, easily adapted to any attribute.
    private static bool IsTypeSerializeable(System.Type type)
    {
        var attributes = type.GetCustomAttributes(false);
        bool hasAttribute = false;
        foreach (var attribute in attributes)
        {
            if (attribute.GetType() == typeof(SerializableAttribute))
            {
                hasAttribute = true;
            }
        }
        if (!hasAttribute)
        {
            Console.WriteLine(type.Name);
        }
        return hasAttribute;
    }
