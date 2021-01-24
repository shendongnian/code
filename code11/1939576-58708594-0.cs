CS
// Create download cancellation token
var downloadCancellationTokenSource = new CancellationTokenSource();
var downloadCancellationToken = downloadCancellationTokenSource.Token;
var completedChecking = false;
// A background task to confirm the download is still progressing
Task.Run(() =>
{
	// Allow the download to start
	Task.Delay(TimeSpan.FromSeconds(2)).GetAwaiter().GetResult();
	long currentStreamLength = 0;
	var currentRetryCount = 0;
	var availableRetryCount = 5;
	// Keep the checking going during the duration of the Download
	while (!completedChecking)
	{
		Console.WriteLine("Checking");
		if (currentRetryCount == availableRetryCount)
		{
			Console.WriteLine($"RETRY WAS {availableRetryCount} - FAILING TASK");
			downloadCancellationTokenSource.Cancel();
			completedChecking = true;
		}
		if (currentStreamLength == memoryStream.Length)
		{
			currentRetryCount++;
			Console.WriteLine($"Length has not increased. Incremented Count: {currentRetryCount}");
			Task.Delay(TimeSpan.FromSeconds(10)).GetAwaiter().GetResult();
		}
		else
		{
			currentStreamLength = memoryStream.Length;
			Console.WriteLine($"Download in progress: {currentStreamLength}");
			currentRetryCount = 0;
			Task.Delay(TimeSpan.FromSeconds(1)).GetAwaiter().GetResult();
		}
	}
});
Console.WriteLine("Starting Download");
blobRef.DownloadToStreamAsync(memoryStream, downloadCancellationToken).GetAwaiter().GetResult();
Console.WriteLine("Completed Download");
completedChecking = true;
Console.WriteLine("Completed");
