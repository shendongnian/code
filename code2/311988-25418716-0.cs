	static MyClass() {
		AOTHint();
	}
	
	static void AOTHint()
	{
		// @fixes: ExecutionEngineException: Attempting to JIT compile method 'System.Collections.Generic.Dictionary`1.FirstOrDefault ()' while running with --aot-only.
		(new Dictionary<string, QueueItem>()).FirstOrDefault();
	}
