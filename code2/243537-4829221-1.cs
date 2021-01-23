    Expect.Call(factory.CreateOrder())
      .Repeat.Once().Return(new Order())
      .Repeat.Once().Return(new Order())
      .Repeat.Once().Return(new Order())
      .Repeat.Once().Return(new Order());
