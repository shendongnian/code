     private void AdjustWidthComboBox_DropDown(object sender, EventArgs e)
            {
                var senderComboBox = (ComboBox)sender;
                int width = senderComboBox.DropDownWidth;
                Graphics g = senderComboBox.CreateGraphics();
                Font font = senderComboBox.Font;
    
                int vertScrollBarWidth = (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                        ? SystemInformation.VerticalScrollBarWidth : 0;
    
                var itemsList = senderComboBox.Items.Cast<object>().Select(item => item.ToString());
    
                foreach (string s in itemsList)
                {
                    int newWidth = (int)g.MeasureString(s, font).Width + vertScrollBarWidth;
    
                    if (width < newWidth)
                    {
                        width = newWidth;
                    }
                }
    
                senderComboBox.DropDownWidth = width;
            }
