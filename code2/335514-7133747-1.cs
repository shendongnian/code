    [Test]
    public void Should_do_something_with_correct_input()
    {
        int inputNumber = 0;
        var service = A.Fake<IService>();
        A.CallTo(() => service.DoSomething(A<int>._))
            .Invokes((int x) => inputNumber = x);
        var system = new System(service);
        system.InvokeService();
        inputNumber.ShouldEqual(100);
    }
