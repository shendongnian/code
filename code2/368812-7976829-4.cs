     private void btnAddEntry_Click(object sender, EventArgs e)
     {
         // Making sure that type is selected.
         if (cmbType.SelectedIndex != -1)
         {
             if (cmbType.SelectedIndex == 0)
             {
                 if(textUserName.Text == String.Empty || textPassword.Text == String.Empty)
                        MessageBox.Show("Please fill all the fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 else
                 {
                     addedEntry.Add(new PCPassword(textUserName.Text, textPassword.Text));
                     MessageBox.Show("Entry was successfully added!", "Entry Added!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     ClearFields();
                 }
             }
             // etc, etc
             // Print our items
             StringBuilder sb = new StringBuilder();
             foreach (Entry item in addedEntry)
             {
                 sb.Append(item.ToString());
             }
             mainWindow.ChangeTextBox = sb.ToString();
         }
     }
