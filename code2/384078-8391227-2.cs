    class Player: Form
	{
		public static int myInt = 0;	//This is where the next screen should be.
		/// <summary>
		/// Constructor.
		/// </summary>
		public Player()
		{
		}
		/// <summary>
		/// Changes MyInt.  Increments myInt so the next corod
		/// </summary>
		private void ButtonPressed()
		{
			myInt++;
			//Note, you need to get the screen size and mode it with this to prevent setting the location off screen.
		}
	}
	class Render
	{
		private Player player;	//Class variable so it persists between calls
		/// <summary>
		/// Constructor.  Sets player.
		/// </summary>
		public Render()
		{
			Location = new Point(Player.myInt, Player.myInt);			//Set my coordinate
		}
		/// <summary>
		/// Shows the value of this.player.MyInt in a message box.
		/// </summary>
		public void rendering_method()
		{
			int i = Player.myInt;
			MessageBox.Show("The value is: " + i);
		}
	}
