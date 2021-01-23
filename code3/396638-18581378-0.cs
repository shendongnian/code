    for (int i = 0; i < 5; i++)
    {
    	stopwatch.Restart();
    	Environment.SetEnvironmentVariable(
    		"Variable " + i,
    		i.ToString(),
    		EnvironmentVariableTarget.Machine);
    	Console.WriteLine(stopwatch.ElapsedMilliseconds + " Variable:" + i);
    }
