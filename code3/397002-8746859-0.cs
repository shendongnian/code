       [TestMethod()]
            public void PointConstructorTest1()
            {
                Point target = new Point(1.5, 2.0);
                Assert.AreEqual(1.5, target.x);
                Assert.AreEqual(2.0, target.y);
            }
