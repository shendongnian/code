public async void button_push()
{
	await genericMethodAsync();
	SynchronousCode1();
}
async Task genericMethodAsync()
{
	 await someOtherAsyncMethodAsync();
	 SynchronousCode2();
	 SyncronousCode3();
}
