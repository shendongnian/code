    static BlockingCollection<int> streamOfBoth = new BlockingCollection<int>();
    // Producer #1 
    static void get1() {
      while (true) {
        System.Threading.Thread.Sleep(1000);
        
        streamOfBoth.Add(1); // value (1) is ready and pushed into streamOfBoth
      }
    }
    // Producer #2
    static void get2() {
      while (true) {
        System.Threading.Thread.Sleep(200);
        streamOfBoth.Add(2); // value (2) is ready and pushed into streamOfBoth
      }
    }
    ...
    Task.Run(() => get1()); // Start producer #1
    Task.Run(() => get2()); // Start producer #2
    ...
    // Cosumer: when either Producer #1 or Producer #2 create a value
    // consumer can starts process it 
    foreach(var item in streamOfBoth.GetConsumingEnumerable()) {
      Console.WriteLine(item);
    }
