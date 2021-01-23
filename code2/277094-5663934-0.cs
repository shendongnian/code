	sw.Start();
	foreach (var item in test)
	{
	}
	sw.Stop();
	Console.WriteLine("foreach " + sw.ElapsedMilliseconds);
	sw.Restart();
	for (int j = 0; j < test.Count; j++)
	{
		T temp = test[j];
	}
	sw.Stop();
	Console.WriteLine("for " + sw.ElapsedMilliseconds);
	sw.Reset(); // -- This bit is missing!
