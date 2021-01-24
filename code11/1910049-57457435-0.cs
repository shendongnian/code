[Fact]
public async void Handle_ShouldAddInstallationRecord_WhenDataIsValid()
{
	Guid testGuid = Guid.NewGuid();
	CreateInstallationCommand command = new CreateInstallationCommand(testGuid, "ABC", "abc@abc.com", null);
	using (TestContextFactory contextFactory = new TestContextFactory())
	{
		using (TestContext seedContext = contextFactory.CreateTestContext())
		{
			seedContext.Apps.Add(new App() { Id = testGuid });
			seedContext.AppRevisions.Add(new AppRevision() { Id = Guid.NewGuid(), AppId = testGuid, Status = AppRevisionStatus.Approved, IsListed = true });
			await seedContext.SaveChangesAsync();
			using (TestContext getContext = contextFactory.CreateTestContext())
			{
				CreateInstallationCommandHandler handler = new CreateInstallationCommandHandler(getContext);
				CommandResult result = await handler.Handle(command, new CancellationToken());
				Assert.True(result);
				Assert.Single(getContext.Installations);
			}
		}
	}
}
