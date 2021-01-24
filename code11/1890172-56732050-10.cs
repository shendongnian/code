    List<bool> cancelRequests = new List<bool>();
    public void OnButtonClick()
    {
    	//we require to pass the reference of the list, so we need to get the index
    	var index = cancelRequests.Count;	
        cancelRequests.Add(false);
        Coroutine co = StartCoroutine(StartCountdown(cooldownDuration, ref cancelRequest[index]));
        myCoroutines.Add(co);
    }
