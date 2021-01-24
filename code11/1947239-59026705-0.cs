    private bool doFill2;
    public void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            time2 = 0;
            doFill2 = true;
        }
    
        if(doFill2)
        {
            if (fillImg2)
            {
                Debug.Log("Got to P2 Reload");
     
                Debug.Log("TEST");
                time2 += Time.deltaTime;
                fillImg2.fillAmount = time2 / timeAmt2;
    
                if(fillImg2.fillAmount >= 1)
                {
                    Debug.Log("TEST COMPLETE");
                }
            }     
        }
        else 
        { 
            Debug.Log("Fill Image 2 is null"); 
        }
    
        // TODO: Do the equivalent for fill1
    }
