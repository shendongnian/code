	[TestMethod]
	public void TriangleConstructorWithFourPoints()
	{
		Point[] s = new []
		{
			new Point { x = 0, y = 0 },
			new Point { x = 4, y = 0 },
			new Point { x = 4, y = 3 }
		};
		Triangle target = new Triangle(s);
		Assert.IsTrue(target.Sides.Contains(3.0));
		Assert.IsTrue(target.Sides.Contains(4.0));
		Assert.IsTrue(target.Sides.Contains(5.0));
	}
