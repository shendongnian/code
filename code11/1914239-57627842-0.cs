    public bool isPunching;
    
    public void AnimationEvent()
    {
    isPunching = false;
    }
    
    void Update()
    {
        isPunching = Input.GetKeyDown(KeyCode.F);
        if(isPunching == false && punchCounter == 0)
        {
            punchCounter = 1;
            isPunching == true;
        }
        else if (isPunching == false && punchCounter == 1)
        {
            punchCounter = 2;
            isPunching == true;
        }
        else if (isPunching == false && punchCounter == 2)
        {
            punchCounter = 3;
            isPunching == true;
        }
        else if (punchCounter == 3)
        {
            punchCounter = 0;
        }
    }
