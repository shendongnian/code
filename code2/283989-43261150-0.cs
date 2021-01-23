    private void searchTb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (lecteurdgview.DataSource as DataTable).DefaultView.RowFilter = String.IsNullOrEmpty(searchTb.Text) ?
                    "lename IS NOT NULL" :
                    String.Format("lename LIKE '{0}' OR lecni LIKE '{1}' OR ledatenais LIKE '{2}' OR lelieu LIKE '{3}'", searchTb.Text, searchTb.Text, searchTb.Text, searchTb.Text);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.StackTrace);
            }
        }
