    Iterable<Ball> redBalls = Enumerable.Where(balls, 
        new Function<Ball, bool>() {
            public bool Execute(Ball b) { return b.getColor() == Color.Red; }
        });
    
