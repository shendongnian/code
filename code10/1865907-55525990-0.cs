DateTime GetTime(double percentage, DateTime startTime, DateTime endTime)
{
	var duration = endTime - startTime;
	var partDuration = percentage * (double)duration.TotalMilliseconds;
    return startTime.AddMilliseconds(partDuration);
}
GetTime(0.5, DateTime.Today.AddHours(4), DateTime.Today.AddHours(16)).Dump();
