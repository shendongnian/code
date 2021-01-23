	public static class ListBoxSelectExtension
	{
	  public static void SetSelected(this ListBox Me)
	  {
		  Me.MouseDown +=
			  (sender, e) =>
			  {
				  if (e.Button == MouseButtons.Right)
					  ((ListBox)sender).ClearSelected();
			  };
	  }
	}
