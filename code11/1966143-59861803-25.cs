    // Thread 1
    private async Task DoJob(string myKey)
    {
      if (dict.TryGetValue(myKey, out MyClass myClass))
      {
        var value = myClass.SomeValueToRead;
        myClass.Prop1 = 10;
        await myClass.DoSomeLongRunningJob(); 
        // The result is now '100' and not '20' because myClass.Prop1 is not thread-safe. The second thread was allowed to change the value while this thread was reading it
        int result = 2 * myClass.Prop1; 
      }
    }
    // Thread 2
    private async Task DoJob(string myKey)
    {
      if (dict.TryGetValue(myKey, out MyClass myClass))
      {
        var value = myClass.SomeValueToRead;
        myClass.Prop1 = 50;
        await myClass.DoSomeLongRunningJob(); 
        int result = 2 * myClass.Prop1; // '100'
      }
    }
