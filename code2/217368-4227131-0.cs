    static IRepository repo;
    static TestController controller;
    static ActionResult result;
    Establish context = () =>
    {
        repo = MockRepository.GenerateMock<IRepository>();
        controller = new TestController(repo);
    };
    //post data to a controller
    Because of = () => result = controller.SaveAction(new SomethingModel() { Name = "test", Description = "test" });
    //controller constructs its own something using the data posted, then saves it. I want to make sure three calls were made.  
    It Should_save_something = () => repo.AssertWasCalled(o => o.Save(Arg<Something>.Is.Anything));
    It Should_save_something_else = () => repo.AssertWasCalled(o => o.Save(Arg<SomethingElse>.Is.Anything));
    It Should_save_another_one = () => repo.AssertWasCalled(o => o.Save(Arg<AnotherOne>.Is.Anything));
}
