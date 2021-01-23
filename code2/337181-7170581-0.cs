	public static class Global
	{
	    public static void TextBoxEmpty<T>(T ContainerControl) where T : Control
	    {
	        foreach (var t in ContainerControl.Controls.OfType<TextBox>())
	        {
	            t.Text = string.Empty; 
	        }
	    }
	}
