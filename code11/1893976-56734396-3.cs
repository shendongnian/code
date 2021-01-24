[FactWithAutomaticDisplayName]
public void Test1() {
  var cb = new ContainerBuilder();
  var studyLoaderMock = new Mock<IAboutTideEditorService>();
  var studyLoaderMock1 = new Mock<IAboutTideEditorRepository>(); // you don't need that when resolving only IAboutTideEditorService
  var studyLoaderMock2 = new Mock<IExceptionLogService>(); // you don't need that when resolving only IAboutTideEditorService
  cb.RegisterInstance(studyLoaderMock.Object).As<IAboutTideEditorService>();
  cb.RegisterInstance(studyLoaderMock1.Object).As<IAboutTideEditorRepository>(); // you don't need that when resolving only IAboutTideEditorService
  cb.RegisterInstance(studyLoaderMock2.Object).As<IExceptionLogService>(); // you don't need that when resolving only IAboutTideEditorService
  var container = cb.Build();
  studyLoaderMock
    .Setup(x => x.AddAboutTideContent(It.IsAny<YourTypeHereForParameterA>,
                                      It.IsAny<YourTypeHereForParameterB>)
             .Returns(new MyResponseDataType()); // add the right types here necessary, I can't tell which types they are because I am not seeing the functions code
  using (var scope = container.BeginLifetimeScope()) {
    var component = scope.Resolve<IAboutTideEditorService>(); // changed to IAboutTideEditorService
    responseData = component.AddAboutTideContent(applicationUser, aboutTide);
    Assert.Equal(ProcessStatusEnum.Invalid, responseData.Status);
  }
}
Your function call was returning `null` because that's the default behavior of a mock with `Moq` = `MockBehavior.Loose`. If you want a function of a mock to return a specific value for non explicit or explicit parameters, you have to call `Setup(delegate)` and `Returns(objectInstance)` or `Returns(Func<ObjectType>)`.
In general your test-setup doesn't make much sense. You are basically only registering mocks with the Autofac-Container which makes the container itself irrelevant for your tests. Using `IoC` for tests is usually only required when you are directly testing against the implementations rather than mocks. Those tests are called `Integration-Tests`.
It would make more sense like this:
[FactWithAutomaticDisplayName]
public void Test1() {
  var cb = new ContainerBuilder();
  var studyLoaderMock1 = new Mock<IAboutTideEditorRepository>();that when resolving only IAboutTideEditorService
  var studyLoaderMock2 = new Mock<IExceptionLogService>();
  var studyLoader = new AboutTideEditorService(studyLoaderMock1.Object, studyLoaderMock2.Object);
  cb.RegisterInstance(studyLoader).As<IAboutTideEditorService>();
  var container = cb.Build();
  // now setup the functions of studyLoaderMock1 and studyLoaderMock2 
  // required for your function `AddAboutTideContent` from `IAboutTideEditorService` to work.
  using (var scope = container.BeginLifetimeScope()) {
    var component = scope.Resolve<IAboutTideEditorService>(); // changed to IAboutTideEditorService
    responseData = component.AddAboutTideContent(applicationUser, aboutTide);
    Assert.Equal(ProcessStatusEnum.Invalid, responseData.Status);
  }
}
Keep in mind that I am assuming here the order of the parameters required for `AboutTideEditorService`. For more information on how to setup mocks with `Moq` take a look [here][1].
  [1]: https://github.com/Moq/moq4/wiki/Quickstart
