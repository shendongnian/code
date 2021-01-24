    private bool doFill2;
    public void Update() 
    {
        // Use the KeyDown only for initializing the counter
        if (Input.GetKeyDown(KeyCode.Space))
        {
            time2 = 0;
            // enable the counter via the flag
            doFill2 = true;
        }
    
        // Every frame check the flag
        if(doFill2)
        {
            if (fillImg2)
            {
                Debug.Log("Got to P2 Reload");
     
                // Only go one incremental step per frame!
                Debug.Log("TEST");
                time2 += Time.deltaTime;
                fillImg2.fillAmount = time2 / timeAmt2;
    
                // Check the fillAmount and if reached one reset the flag and stop the fill
                if(fillImg2.fillAmount >= 1)
                {
                    Debug.Log("TEST COMPLETE");
                    doFill2 = false;
                }
            }     
        }
        else 
        { 
            Debug.Log("Fill Image 2 is null"); 
        }
    
        // TODO: Do the equivalent for fill1
    }
