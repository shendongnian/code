    // initialize to some value reasonable for not being health category.
    int newDefaultDaysRemaining = 1000;
    bool newOutsideHealthCategory = true;
    // Determine what category of health you are in now
    if (statsHealth <= -10f && statsHealth > -25f)
    {
        //Enable Health Hazard
        isHealthHazard = true;
        newOutsideHealthCategory = false;
        newDefaultDaysRemaining = 10;
    }
    else if (statsHealth <= -25f && statsHealth > -35f)
    {
        //Enable Health Hazard
        isHealthHazard = true;
        newOutsideHealthCategory = false;
        newDefaultDaysRemaining = 8;
    }
    else if (statsHealth <= -35f && statsHealth > -40f)
    {
        //Enable Health Hazard
        isHealthHazard = true;
        newOutsideHealthCategory = false;
        //Set Days Remaining
        newDefaultDaysRemaining = 5;
        
    }
    else if (statsHealth <= -40f && statsHealth > -50f)
    {
        //Enable Health Hazard
        isHealthHazard = true;
        newOutsideHealthCategory = false;
        newDefaultDaysRemaining = 2;
    }
    // Decrease timer 
    daysRemaining -= 1;
   
    if (previousOutsideHealthCategory) 
    {
        // We were not in a category previously, just set the days remaining
        daysRemaining = newDefaultDaysRemaining;
    } 
    else 
    {
        // reduce or increase daysRemaining by any category change
        daysRemaining += newDefaultDaysRemaining - previousDefaultDaysRemaining;
    }
    // remember the new category's days remaining and 
    // our outsideHealthCategory status if either changed
    previousDefaultDaysRemaining = newDefaultDaysRemaining;
    previousOutsideHealthCategory = newOutsideHealthCategory;
    // check for critical health status boundaries
    if(statsHealth > -10 && hasIssues)
    {
        //GAME OVER
        Debug.Log("GAME OVER!");
        daysRemaining = 0;
    }
    else if(statsHealth >= 0)
    {
        //No More Health Issues
        isHealthHazard = false;
    }            
