    public class AspNetCoreIntegrationTestBase {
	public CancellationTokenSource CancellationTokenSource {
		get;
		private set;
	}
	public Task TestWebserver {
		get;
		private set;
	}
	[OneTimeSetUp]
	public void Setup() {
		CancellationTokenSource = new CancellationTokenSource();
		TestWebserver = Program.CreateHostBuilder(new string[0]).Build().StartAsync(CancellationTokenSource.Token);
	}
	[OneTimeTearDown]
	public void CleanUp() {
		CancellationTokenSource.Cancel();
		TestWebserver.Dispose();
	}
