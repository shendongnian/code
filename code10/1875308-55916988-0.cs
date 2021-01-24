        private void addBtn_Click(object sender, EventArgs e)
        {
            bool similarItem = false;
            if (!String.IsNullOrEmpty(itemText.Text.Trim()))
            {
                foreach (string listItem in itemListBox.Items)
                {
                    if (listItem == itemText.Text)
                    {
                        MessageBox.Show("Similar item detected");
                        similarItem = true;
                        break;
                    }
                }
                    
                if(!similarItem)
                    itemListBox.Items.Add(itemText.Text);
            }
        }
