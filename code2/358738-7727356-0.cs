    // Queue to keep tasks and their callbacks
    private BlockingCollection<Tuple<Task<Foo>, CreatedDelegate>> 
      queue = new BlockingCollection<Tuple<Task<Foo>, CreatedDelegate>>()
    public void CreateAsync(CreatedDelegate createdCallback) {
        Task<Foo> t = Task.Factory.StartNew(() =>  { 
          Foo result = ... 
          return result; });
        queue.Add(Tuple.Create(t, createdCallback));
        // ..
    }
