    private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) 
        { 
            String filterStatus = DataGridViewAutoFilterColumnHeaderCell.GetFilterStatus(dataGridView1); 
            if (String.IsNullOrEmpty(filterStatus)) 
            { 
                showAllLabel.Visible = false; 
                filterStatusLabel.Visible = false; 
            } 
            else 
            { 
                int result = -1;
                Int32.TryParse(filterStatus, out result);
                if (result != 0)
                {
                     // it is a number
                     showAllLabel.Visible = true; 
                     filterStatusLabel.Visible = true; 
                     filterStatusLabel.Text = filterStatus; 
                }
                else
                {
                     // it is not a number
                }
            } 
        }
