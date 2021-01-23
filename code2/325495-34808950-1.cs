		static void Main(string[] args)
		{
			const int noObjects = 20*1000*1000;
			Console.WriteLine("List:");
			RunTest(new List<TestClass>(), noObjects);
			RunTest(new List<TestStruct>(), noObjects);
			Console.WriteLine();
			Console.WriteLine("Initialized List:");
			RunTest(new List<TestClass>(noObjects), noObjects);
			RunTest(new List<TestStruct>(noObjects), noObjects);
			Console.WriteLine();
			Console.WriteLine("LinkedList:");
			RunTest(new LinkedList<TestClass>(), noObjects);
			RunTest(new LinkedList<TestStruct>(), noObjects);
			Console.WriteLine();
			Console.WriteLine("HashSet:");
			RunTest(new HashSet<TestClass>(), noObjects);
			RunTest(new HashSet<TestStruct>(), noObjects);
			Console.WriteLine();
			Console.WriteLine("Now I added a string to the class/struct:");
			Console.WriteLine("List:");
			RunTest(new List<TestClassWithString>(), noObjects);
			RunTest(new List<TestStructWithString>(), noObjects);
			Console.WriteLine();
			Console.ReadLine();
		}
		private static void RunTest<T>(ICollection<T> collection, int noObjects) where T : ITestThing
		{
			Stopwatch sw = new Stopwatch();
			sw.Restart();
			for (int i = 0; i < noObjects; i++)
			{
				var obj = Activator.CreateInstance<T>();
				collection.Add(obj);
			}
			sw.Stop();
			Console.WriteLine("Adding " + noObjects + " " + typeof(T).Name + " to a " + collection.GetType().Name + " took " + sw.Elapsed.TotalMilliseconds + " ms");
			if (collection is IList)
			{
				IList list = (IList) collection;
				// access all list objects
				sw.Restart();
				for (int i = 0; i < noObjects; i++)
				{
					var obj = list[i];
				}
				sw.Stop();
				Console.WriteLine("Accessing " + noObjects + " " + typeof (T).Name + " from a List took " + sw.Elapsed.TotalMilliseconds + " ms");
			}
		}
