    var A = Task.Factory.StartNew(
      () => Console.WriteLine("A"));
    var B = Task.Factory.StartNew(
      () => Console.WriteLine("B"));
    var E = Task.Factory.StartNew(
      () => Console.WriteLine("E"));
    var C = Task.Factory.StartNew(
      () => { Task.WaitAll(A, B); Console.WriteLine("C"); });
    var D = Task.Factory.StartNew(
      () => { Task.WaitAll(C, E); Console.WriteLine("D"); });
    Task.Factory.StartNew(
      () => { Task.WaitAll(E, D); Console.WriteLine("F"); })
        .ContinueWith(a => Console.WriteLine("G"));
