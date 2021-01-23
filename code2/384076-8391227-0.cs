    class Player
	{
		/// <summary>
		/// Constructor.  Sets MyInt.
		/// </summary>
		public Player()
		{
			MyInt = 0;
		}
		/// <summary>
		/// Auto-Implemented property.  http://msdn.microsoft.com/en-us/library/bb384054.aspx
		/// </summary>
		public int MyInt
		{
			get;
			protected set;	//Protected to prevent outside modification while debugging.
		}
		/// <summary>
		/// Changes MyInt.
		/// </summary>
		private void ButtonPressed()
		{
			MyInt++;
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
			player = new Player();
		}
		/// <summary>
		/// Shows the value of this.player.MyInt in a message box.
		/// </summary>
		public void ShowInt()
		{
			int i = player.MyInt;
			MessageBox.Show("The value is: " + i);
		}
	}
