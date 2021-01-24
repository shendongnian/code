      private void button1_Click(object sender, EventArgs e)
        {
            try
            {
		        DataTable dt = new DataTable();
                cmdbl = new SqlCommandBuilder(adapt);
                adapt.Update(dt);
                MessageBox.Show("Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
