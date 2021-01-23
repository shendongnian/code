    public struct PointStruct
		{
			public int X;
		}
		public class PointClass
		{
			public int X;
		}
		[TestMethod]
		public void TestStruct()
		{
			var structArray = new PointStruct[1];
			var classArray = new PointClass[1];
			int x;
			
			x = structArray[0].X;
			try
			{
				x = classArray[0].X;
			}
			catch(NullReferenceException e)
			{
				Console.WriteLine(e.Message);
			}
			classArray[0] = new PointClass();
			// It's now ok
			x = classArray[0].X;
			var point1 = structArray[0];
			var point2 = classArray[0];
			point1.X = 1;
			point2.X = 1;
			Assert.IsTrue(point2.X == 1);
			Assert.IsFalse (structArray[0].X == 1);
			structArray[0].X = 1;
			Assert.IsTrue(structArray[0].X == 1);
		}
