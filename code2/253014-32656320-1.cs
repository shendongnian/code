	void Main()
	{
		// even is okay, odd will cause exception
		var operations = new[] { 2, 16, 5 /* ! */, 8, 91 /* ! */ };
		
		var results = process(operations);
		var en = results.GetEnumerator();
		
		"Regular Enumeration".Title();
		testEnumeration(en);
		
		results = process(operations, ex => log("Handled: {0}", ex.Message));
		en = results.GetEnumerator();	
		
		"Handled Exceptions".Title();
		testEnumeration(en);
		results = process(operations, ex => log("Handled+: {0}", ex.Message), true);
		en = results.GetEnumerator();	
		
		"Handled Exceptions and Continue".Title();
		testEnumeration(en);
	}
	
	/// run the test and debug results
	void testEnumeration(IEnumerator en) {
		int successCount = 0, failCount = 0;
		bool keepGoing = false;
		do {
			try {
				log("==={0}===", "before next");
				keepGoing = en.MoveNext();
				log("==={0}=== (keepGoing={1}, curr={2})", "after next", keepGoing, en.Current);
				
				// did we have anything?
				if(keepGoing) {
					var curr = en.Current;
					log("==={0}===", "after curr");
					
					log("We did it? {0}", curr);
					successCount++;
				}
			}
			catch(InvalidOperationException iopex) {
				log(iopex.Message);
				failCount++;
			}
		} while(keepGoing);
		
		log("Successes={0}, Fails={1}", successCount, failCount);
	}
	
	/// enumerable that will stop completely on errors
	IEnumerable<int> process(IEnumerable<int> stuff) {
		foreach(var thing in stuff) {
			if(thing % 2 == 1) {
				throw new InvalidOperationException("Aww, you broked it");
			}
			
			yield return thing;
		}
	}
	/// enumerable that can yield from exceptions
	IEnumerable<int> process(IEnumerable<int> stuff, Action<Exception> handleException, bool yieldOnExceptions = false) {
		bool shouldYield = false;
		foreach(var thing in stuff) {
			var result = thing;
			try {
				if(thing % 2 == 1) {
					throw new InvalidOperationException("Aww, you broked it");
				}
				
				shouldYield = true;
			}
			catch(Exception ex) {
				handleException(ex);
				// `yield break` to stop loop
				shouldYield = yieldOnExceptions;
				if(yieldOnExceptions) result = -1; // so it returns a different result you could interpret differently
			}
			if(shouldYield) yield return result;
		}
	}
	
	void log(string message, params object[] tokens) {
		Console.WriteLine(message, tokens);
	}
