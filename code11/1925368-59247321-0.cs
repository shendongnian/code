CS
var timer = Stopwatch.StartNew();
try
{
	var resultTask = client.GetStringAsync("http://example.com");
	while (timer.Elapsed.TotalSeconds <= 2 && !resultTask.IsCompleted)
		await Task.Delay(100);
	if (!resultTask.IsCompleted)
		throw new Exception();
	string reply = resultTask.Result;
}
catch
{
	throw;
}
finally
{
	timer.Stop();
}
