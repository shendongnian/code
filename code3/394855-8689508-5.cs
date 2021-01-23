	public void PerformSomeTask() {
		// This task has 2 steps; the first step takes about 20%, and the second takes 80%:
		Progress.BeginWeightedTask(20, 80);
		
		// Start the first step (20%):
		Progress.NextStep();
		TaskA();
		
		// Start the second step (80%):
		Progress.NextStep();
		TaskB();
		
		// Finished!
		Progress.EndTask();		
	}
	
	
	public void TaskA() {
		int count = 20;
		// This task has 20 steps:
		Progress.BeginFixedTask(count);
		
		for (int i = 0; i < count; i++) {
			Progress.NextStep();
			// ...
		}
		
		Progress.EndTask();
	}
	public void TaskB() {
		// This task has an unknown number of steps
		// We will estimate about 20, with a confidence of .5
		Progress.BeginUnknownTask(20, .5);
		
		while (database.ReadRow()) {
			Progress.NextStep();
			// ...
		}
		Progress.EndTask();
	}
	
