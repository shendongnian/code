	public class MyGame
	{
        private MethodInfo pActivate;
		public MyGame()
		{
			// We need to access base HostActivate method, that unfortunally, is private!
			// We need to use reflection then, of course this method is an hack and not a real solution!
			// Ask Microsoft for a better implementation of their class!
            this.pActivate = typeof(Game).GetMethod("HostActivated", BindingFlags.NonPublic | BindingFlags.Instance);
		}
		
        protected sealed override void OnDeactivated(object sender, EventArgs args)
        {
            this.pIsWindowActive = false;
            base.OnDeactivated(sender, args);
			
			// Ok, the game form was deactivated, we need to make it believe the form was activated just after deactivation.
			if (!base.Active)
			{
				// Force activation by calling base.HostActivate private methods.
				this.pActivate.Invoke(this, new object[] { sender, args });
			}
        }
	}
