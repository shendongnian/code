    var queue = new Queue<int>(new [] {1, 2, 3});
    var mockObject = MockRepository.GenerateMock<IdGenerator>();
    mockObject.Expect(calc => calc.GetNext())
              .Do( (Func<int>) queue.Dequeue);
    
    Console.Out.WriteLine(mockObject.GetNext()); // returns 1
    Console.Out.WriteLine(mockObject.GetNext()); // returns 2
    Console.Out.WriteLine(mockObject.GetNext()); // returns 3
