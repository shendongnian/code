	public void PauseGame()
    {
		...your code here, with no changes...
        EventManager.StartListening("ReturnMainMenu", (e) =>
        {
            //---> Removed ->Cooldown.cancelAllCoroutines();
			//replaced by this
            Timing.KillCoroutines("CooldownTag");
            ...your code here, with no changes...
        });
        ...
