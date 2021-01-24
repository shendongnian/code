    //the event somewhere in this script
	public static event Action OnCancelCooldowns;
	
	public void PauseGame()
    {
		...your code here, with no changes...
        EventManager.StartListening("ReturnMainMenu", (e) =>
        {
            //---> Removed ->Cooldown.cancelAllCoroutines();
			//replaced by the event
			OnCancelCooldowns?.Invoke();
            ...your code here, with no changes...
        });
        ...
