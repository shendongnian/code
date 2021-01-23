        private void SelectedItem(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (tabSelectPage.SelectedTab == tabPage1)
                txtSelected.Text = " User Name:  " + e.Item.SubItems[1].Text +
                    "     Password:  " + e.Item.SubItems[2].Text;
            else if (tabSelectPage.SelectedTab == tabPage2)
                txtSelected.Text = " URL:  " + e.Item.SubItems[1].Text +
                    "     User Name:  " + e.Item.SubItems[2].Text +
                    "     Password:  " + e.Item.SubItems[3].Text;
            else if (tabSelectPage.SelectedTab == tabPage3)
                txtSelected.Text = " Software Name:  " + e.Item.SubItems[1].Text +
                    "     Serial Code:  " + e.Item.SubItems[2].Text;
        }
