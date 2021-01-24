     private void btnUpdate_Click(object sender, EventArgs e)
     {
        try
        {
            DB db_con = new DB();
            db_con.constr.Open();
            MySqlCommand cmd = new MySqlCommand("update tbl_patients set name='" + txtName.Text+"', age='"+txtAge.Text+"', address='"+txtAddress.Text+"',phone='"+txtPhone.Text+"',doctor='"+cmbDoctor.Text+"',category='"+cmbCategory.Text+"' where id="+patient_id, db_con.constr);
            cmd.ExecuteNonQuery();                
            db_con.constr.Close();
            
            // Close edit dialog
            this.DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    view form:
    using (EditPatient editp = new EditPatient())
    {
         editp.patient_id = id;
         if (editp.ShowDialog() == DialogResult.OK)
         {
             // refresh view dataset
             // this.refreshDataset();
         }
     }
