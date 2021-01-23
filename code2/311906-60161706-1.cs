        if (!listBox1.ClientRectangle.Contains(listBox1.PointToClient(Control.MousePosition)))
    	{
    		if (listBox1.Size.Width == 500)
    		{
    			listBox1.Size = new Size(listBox1.Size.Width - 200, listBox1.Size.Height);
    		}
    	}
