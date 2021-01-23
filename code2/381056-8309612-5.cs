        [TestMethod]
        public void RectDoesNotIntersect()
        {
            var a = new Rectangle(0, 0, 10, 10);
            var b = new Rectangle(20, 20, 10, 10);
            var result = Program.DetectEdgesCollision(a, b);
            Assert.AreEqual<Edges>(Edges.None, result);
        }
 
        [TestMethod]
        public void RectAreNested()
        {
            var a = new Rectangle(0, 0, 30,30);
            var b = new Rectangle(10, 10, 10, 10);
            var result = Program.DetectEdgesCollision(a, b);
            Assert.AreEqual<Edges>(Edges.Inside, result);
        }      
        [TestMethod]
        public void RectCollidesOnTopAndLeft()
        {
            var a = new Rectangle(10, 10, 10, 10);
            var b = new Rectangle(0, 0, 10, 10);
            var result = Program.DetectEdgesCollision(a, b);
            Assert.AreEqual<Edges>(Edges.Left | Edges.Top, result);
        }     
        [TestMethod]
        public void RectCollidesOnBottom()
        {
            var a = new Rectangle(0, 0, 20, 20);
            var b = new Rectangle(10, 10, 5, 50);
            var result = Program.DetectEdgesCollision(a, b);
            Assert.AreEqual<Edges>(Edges.Bottom , result);
        }        
        
        [TestMethod]
        public void RectAreIdenticals()
        {
            var a = new Rectangle(10, 10, 10, 10);
            var b = new Rectangle(10, 10, 10, 10);
            var result = Program.DetectEdgesCollision(a, b);
            Assert.AreEqual<Edges>(Edges.Identical, result);
        }  
        [TestMethod]
        public void RectBCoversA()
        {
            var a = new Rectangle(10, 10, 10, 10);
            var b = new Rectangle(0, 0, 30, 30);
            var result = Program.DetectEdgesCollision(a, b);
            Assert.AreEqual<Edges>(Edges.Covers, result);
        }     
