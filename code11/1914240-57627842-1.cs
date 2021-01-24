    public bool isAnimating;
    
    public void AnimationEvent()
    {
         isAnimating = false;
    }
    
    void Update()
    {
        isPunching = Input.GetKeyDown(KeyCode.F);
        if(isAnimating == false && isPunching && punchCounter == 0)
        {
            punchCounter = 1;
            isAnimating = true;
        }
        else if (isAnimating == false  && isPunching && punchCounter == 1)
        {
            punchCounter = 2;
            isAnimating = true;
        }
        else if (isAnimating == false  && isPunching && punchCounter == 2)
        {
            punchCounter = 3;
            isAnimating = true;
        }
        else if (punchCounter == 3)
        {
            punchCounter = 0;
        }
    }
