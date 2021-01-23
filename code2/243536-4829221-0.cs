    mockFactory.Expect(x => x.CreateOrder())
      .Repeat.Once().Return(new Order())
      .Repeat.Once().Return(new Order())
      .Repeat.Once().Return(new Order())
      .Repeat.Once().Return(new Order());
