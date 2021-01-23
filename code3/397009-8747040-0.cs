    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Cannot_Create_Passing_Null()
    {
       new Triangle(null);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Cannot_With_Less_Than_Three_Points()
    {
       new Triangle(new[] { new Point(0, 0), new Point(1, 1) });
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Cannot_Create_With_More_Than_Three_Points()
    {
       new Triangle(new[] { new Point(0, 0), new Point(1, 1), new Point(2, 2), new Point(3, 3) });
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Cannot_Create_With_Two_Identical_Points()
    {
       new Triangle(new[] { new Point(0, 0), new Point(0, 0), new Point(1, 1) });
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Cannot_Create_With_Empty_Array()
    {
       new Triangle(new Point[] { });
    }
