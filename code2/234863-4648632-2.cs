    [Test]
    public void AllOurPocosNeedToBeSerializable()
    {
      Assembly assembly = Assembly.GetAssembly(typeof (PutInPocoElementHere));
      int failingTypes = 0;
      foreach (var type in assembly.GetTypes())
      {
        if(type.IsSubclassOf(typeof(Entity)))
        {
           if (!(type.HasAttribute<SerializableAttribute>())) failingTypes++;
           Console.WriteLine(type.Name);
           //whole test would be more concise with an assert within loop but my way
           //you get all failing types printed with one run of the test.
        }
      }
      Assert.That(failingTypes, Is.EqualTo(0), string.Format("Look at console output 
         for other types that need to be serializable. {0} in total ", failingTypes));
    }
    //refer to Robert's answer below for improved attribute check, HasAttribute
