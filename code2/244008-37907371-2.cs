    private void combo_DropDown(object sender, EventArgs e)
	{
		//http://www.codeproject.com/Articles/5801/Adjust-combo-box-drop-down-list-width-to-longest-s
		ComboBox senderComboBox = (ComboBox)sender;
		int width = senderComboBox.DropDownWidth;
		Graphics g = senderComboBox.CreateGraphics();
		Font font = senderComboBox.Font;
		int vertScrollBarWidth =
			(senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
			? SystemInformation.VerticalScrollBarWidth : 0;
		int newWidth;
		foreach (string s in ((ComboBox)sender).Items)
		{
			newWidth = (int)g.MeasureString(s, font).Width
				+ vertScrollBarWidth;
			if (width < newWidth)
			{
				width = newWidth;
			}
            if (senderComboBox.Width < newWidth)
            {
                senderComboBox.Width = newWidth+ SystemInformation.VerticalScrollBarWidth;
            }
		}
		senderComboBox.DropDownWidth = width;
	}
