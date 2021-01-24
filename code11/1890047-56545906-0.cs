    public bool[] Collisions(Rectangle hero, Rectangle rect)
    {
    	var intersection = Rectangle.Intersect(hero, rect);
    	if(intersection.IsEmpty){
    		return new []{ false, false, false, false };
    	}
    	
        bool hitSomethingAbove = hero.Top == intersection.Top;
        bool hitSomethingBelow = hero.Bottom == intersection.Bottom;
        bool hitSomethingOnTheRight = hero.Right == intersection.Right;
        bool hitSomethingOnTheLeft = hero.Left == intersection.Left;
    
        return new bool[] 
    	{ 
    		hitSomethingAbove, 
    		hitSomethingBelow, 
    	    hitSomethingOnTheRight, 
    		hitSomethingOnTheLeft, 
    	};
    }
