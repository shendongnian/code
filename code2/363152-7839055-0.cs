    class Balls
    {
        public int redBalls { get; set; }
        public int blueBalls{ get; set; }
        public int totalBalls{ get{ return redBalls + blueBalls; } }
    }
    void test()
    {
        // You must acutally set the value of redBalls/blueBalls
        var balls = new Balls{ redBalls = 1, blueBalls = 2 };
        Assert.AreEqual(3, balls.totalBalls);
    }
