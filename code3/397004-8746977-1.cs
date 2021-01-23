        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TriangleConstructorWithNullPoints()
        {
            Point[] s = null; 
            Triangle target = new Triangle(s);
        }
	[TestMethod]        
	[ExpectedException(typeof(ArgumentException))]        
	public void TriangleConstructorWithFourPoints()        
	{
		Point[] s = new Point[4];
		Triangle target = new Triangle(s);        
	}
