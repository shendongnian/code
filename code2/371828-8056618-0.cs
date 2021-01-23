     private void CheckBox1_CheckedChanged(System.Object sender, System.EventArgs e)
     {
    
       DataGridViewColumn dgvColumn = this.DataGridView1.Columns("Details");
    
        if (this.CheckBox1.CheckState == CheckState.Checked)
        {
             dgvColumn.ReadOnly = true;
        }
        else 
        dgvColumn.ReadOnly = false;              
         
     }
