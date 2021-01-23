	[TestClass]
	public class DateTimeRangeTests
	{
		[TestMethod]
		public void overlap_dates_is_interscected_second_newer_test()
		{
			//|--- Date 1 ---|
			//	  | --- Date 2 --- |
			DateTime baseTime = DateTime.Now;
			var r1 = new DateTimeRange(baseTime.AddDays(-4), baseTime.AddDays(-2));
			var r2 = new DateTimeRange(baseTime.AddDays(-3), baseTime.AddDays(-1));
			Assert.IsTrue(r1.Intersects(r2));
		}
		[TestMethod]
		public void overlap_dates_is_interscected_second_older_test()
		{
			//        |--- Date 1 ---|
			//	  | --- Date 2 --- |
			DateTime baseTime = DateTime.Now;
			var r1 = new DateTimeRange(baseTime.AddDays(-3), baseTime.AddDays(-1));
			var r2 = new DateTimeRange(baseTime.AddDays(-4), baseTime.AddDays(-2));
			Assert.IsTrue(r1.Intersects(r2));
		}
		[TestMethod]
		public void overlap_dates_is_interscected_second_subset_of_first_test()
		{
			//| -------- Date 1 -------- |
			//	 | --- Date 2 --- |
			DateTime baseTime = DateTime.Now;
			var r1 = new DateTimeRange(baseTime.AddDays(-4), baseTime.AddDays(-1));
			var r2 = new DateTimeRange(baseTime.AddDays(-3), baseTime.AddDays(-2));
			Assert.IsTrue(r1.Intersects(r2));
		}
		[TestMethod]
		public void overlap_dates_is_interscected_second_superset_of_first_test()
		{
			//| -------- Date 1 -------- |
			//	 | --- Date 2 --- |
			DateTime baseTime = DateTime.Now;
			var r1 = new DateTimeRange(baseTime.AddDays(-3), baseTime.AddDays(-2));
			var r2 = new DateTimeRange(baseTime.AddDays(-4), baseTime.AddDays(-1));
			Assert.IsTrue(r1.Intersects(r2));
		}
		[TestMethod]
		public void non_intersects_dates_when_second_before_first_test()
		{
			//                        | --- Date 1 -------- |
			//	 | --- Date 2 --- |
			DateTime baseTime = DateTime.Now;
			var r1 = new DateTimeRange(baseTime.AddDays(-1), baseTime.AddDays(0));
			var r2 = new DateTimeRange(baseTime.AddDays(-4), baseTime.AddDays(-2));
			Assert.IsFalse(r1.Intersects(r2));
		}
		[TestMethod]
		public void non_intersects_dates_when_second_after_first_test()
		{
			//   | --- Date 1 ------ |
			//	                        | --- Date 2 --- |
			DateTime baseTime = DateTime.Now;
			var r1 = new DateTimeRange(baseTime.AddDays(-4), baseTime.AddDays(-2));
			var r2 = new DateTimeRange(baseTime.AddDays(-1), baseTime.AddDays(-0));
			Assert.IsFalse(r1.Intersects(r2));
		}
	}
