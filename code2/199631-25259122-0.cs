    static void Main(string[] args) {
      bool wasNewMutexCreated;
      using (var mutext = new Mutex(false, "MyMutext", out wasNewMutexCreated)) {
        if (!wasNewMutexCreated) {
          Console.Out.WriteLine("Can't continue - MyMutex is in use.");
        }
        // rest of your application logic
        Console.In.ReadLine();
      }
    }
