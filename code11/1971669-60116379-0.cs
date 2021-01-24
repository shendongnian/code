cs
    void Update () 
    {
        if (leftMouseButtonWasClicked) { count++; CallOnClickCount(count); }
		count %= maxCount;
    }
		
	public void CallOnClickCount(int number)
	{
		switch (number)
		{
			case 1:
				//logic
				Debug.Log("logic " + count);
				break;
			case 2:
				//logic
				Debug.Log("logic " + count);
				break;
			case 3:
				//logic
				Debug.Log("logic " + count);
				break;
		}
	}
