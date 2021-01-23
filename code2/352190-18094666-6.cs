   	[TestFixture]
	public class When_starting_process
	{
		[Test]
		public void Should_return_started_status()
		{
			if (AzureStorageEmulatorManager.IsProcessRunning())
			{
				AzureStorageEmulatorManager.StopStorageEmulator();
				Assert.That(AzureStorageEmulatorManager.IsProcessRunning(), Is.False);
			}
			AzureStorageEmulatorManager.StartStorageEmulator();
			Assert.That(AzureStorageEmulatorManager.IsProcessRunning(), Is.True);
		}
	}
	[TestFixture]
	public class When_stopping_process
	{
		[Test]
		public void Should_return_stopped_status()
		{
			if (!AzureStorageEmulatorManager.IsProcessRunning())
			{
				AzureStorageEmulatorManager.StartStorageEmulator();
				Assert.That(AzureStorageEmulatorManager.IsProcessRunning(), Is.True);
			}
			AzureStorageEmulatorManager.StopStorageEmulator();
			Assert.That(AzureStorageEmulatorManager.IsProcessRunning(), Is.False);
		}
	}
