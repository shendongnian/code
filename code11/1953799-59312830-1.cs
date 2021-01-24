csharp
public class TestedServiceTest
{
    readonly Mock<IDependency> m_dependencyMock;
    readonly Mock<ISecondDependency> m_secondDependencyMock;
    ITestedService testedService;
    public TestedServiceTest()
    {
        m_dependencyMock = new Mock<IDependency>();
        m_secondDependencyMock = new Mock<ISecondDependency>();
        testedService = new TestedService(m_dependencyMock.Object, m_secondDependencyMock.Object);
    }
    
    [Fact]
    public async Start_DependencyStartInvoked()
    {
        // Arrange
        m_dependencyMock.Setup(x=> x.Start()).Verifyable();
        // Act 
        await testedService.Start();
        // Assert
        //This tests if the IDependecy.Start is invoked once.
        m_dependencyMock.Verify(x=>x.Start(), Times.Once);
    }
    [Fact]
    public async Start_EventListenerAttached()
    {
        // Arrange
        m_dependencyMock.Setup(x=> x.Start()).Verifyable();
        m_dependencyMock.SetupAdd(m => m.SomethingHappened += (sender, args) => { });
        // Act 
        await testedService.Start();
        // Assert
        // The below together with SetupAdd above asserts if the TestedService.Start adds a new eventlistener
        // for IDependency.SomethingHappened
        m_dependencyMock.VerifyAdd(
            m => m.SomethingHappened += It.IsAny<EventHandler<SoAndSoEventArgs>>(), 
            Times.Exactly(1));
    }
    [Fact]
    public async Start_SomthingHappenedInvoked_HandlerExecuted()
    {
        // Arrange
        m_dependencyMock.Setup(x=> x.Start()).Verifyable();
        m_secondDependencyMock.Setup(x=> x.DoYourJob(It.IsAny<SoAndSo>())).Verifyable();
        // Act
        await testedService.Start();
        // This will fire the event SomethingHappened from m_dependencyMock.
        m_dependencyMock.Raise(m => m.SomethingHappened += null, new SoAndSoEventArgs());
        // Assert
        // Assertion to check if the handler does its job.
        m_secondDependencyMock.Verify(x=> x.DoYourJob(It.IsAny<SoAndSo>()), Times.Once);
    }
}
