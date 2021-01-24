    if (trigCont > 50)
    {
        if (trigCont == 51)
        {
            //...          
                        
    		
    		for (int i = 0; i < Camera.main.transform.childCount; i++)
    		{
    			if (Camera.main.transform.GetChild(i).GetComponent<ParticleSystem>() != null)
    			{
    				Camera.main.transform.GetChild(i).GetComponent<ParticleSystem>().Play();
    			}
    		}
    		CancelInvoke("Check");
    		Invoke("nextScene", 0);
        }               
    }
