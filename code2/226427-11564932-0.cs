    private void AdjustWidthComboBox_DropDown(object sender, System.EventArgs e)
    {
        ComboBox senderComboBox = (ComboBox)sender;
        int width = senderComboBox.DropDownWidth;
        Graphics g = senderComboBox.CreateGraphics();
        Font font = senderComboBox.Font;
        int vertScrollBarWidth = 
            (senderComboBox.Items.Count>senderComboBox.MaxDropDownItems)
            ?SystemInformation.VerticalScrollBarWidth:0;
    
        int newWidth;
        foreach (string s in ((ComboBox)sender).Items)
        {
            newWidth = (int) g.MeasureString(s, font).Width 
                + vertScrollBarWidth;
            if (width < newWidth )
            {
                width = newWidth;
            }
        }
        senderComboBox.DropDownWidth = width;
    }
