		public class ATest
		{
			public int number { get; set; }
			public int boo { get; set; }
			public ATest()
			{
			}
		}
		protected void Go()
		{
			List<ATest> list = new List<ATest>();
			foreach(var i in Enumerable.Range(0,30)) {
				foreach(var j in Enumerable.Range(0,100)) {
					list.Add(new ATest() { number = i, boo = j });					
				}
			}
			var o =0; //only for proving concept.
			foreach (ATest aTest in list)
			{				
				DoSomthing(aTest);
				//proof that this does work in this example.
				o++;
				System.Diagnostics.Debug.Assert(o == list.IndexOf(aTest));
			}
		}
