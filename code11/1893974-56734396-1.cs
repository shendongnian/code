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
