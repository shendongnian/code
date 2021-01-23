    int numberOfIterations = 100000000;
    Stopwatch sw = new Stopwatch();
	sw.Start();
	for (int i = 0; i < numberOfIterations; i++)
	{
		var x = (dynamic)2.87; 
	}
	sw.Stop();
	sw.Restart();
	for (int i = 0; i < numberOfIterations; i++)
	{
		double y = 2.87; 
	}
	sw.Stop();
