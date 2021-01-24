    int desiredClickCount = 2;
    int leftClickCount = 0;
    if(leftmousebuttonclicked)
    {
        if(leftClickCount < desiredClickCount)
    	{
            leftClickCount++;
    	}
    	else
        {
           leftClickCount = 0;
    	   //clickCountLogic logic
        }
    }
    else
    {
       leftClickCount = 0;
    }
