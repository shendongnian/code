    public class MenuItem
	{
		public string title = "Item";
		public bool enabled = true;
		public int width = 100;
		public string relatedLeftDockPanel = "";
		public string relatedRightDockPanel = "";
		public Button.ButtonClickedEvent onClick = null;
	}
	[Serializable]
	public class MenuItemLevel0 : MenuItem
	{
		public MenuItemLevel1[] submenu;
	}
	[Serializable]
	public class MenuItemLevel1 : MenuItem
	{
		public MenuItemLevel2[] submenu;
	}
	[Serializable]
	public class MenuItemLevel2 : MenuItem
	{
	}
