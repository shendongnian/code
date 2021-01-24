    var collection = Enumerable.Range(0, 1000000).ToArray();;
			
    Stopwatch st = new Stopwatch();
			
	st.Start();
			
	var item = collection.Contains(450023);
			
	st.Stop();
			
	var timeTaken = st.Elapsed.TotalMilliseconds;
			
	Console.WriteLine("Time taken by Contains : {0}", timeTaken);
			
	st.Restart();
	var x = Array.BinarySearch(collection, 973812);
	st.Stop();
			
	timeTaken = st.Elapsed.TotalMilliseconds;
			
	Console.WriteLine("Time taken by BinarySearch : {0}", timeTaken);
