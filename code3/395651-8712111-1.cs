    private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.SuspendLayout();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1[0, i].Value = ((CheckBox)dataGridView1.Controls.Find("checkboxHeader", true)[0]).Checked;
            }
            dataGridView1.ResumeLayout();
        }  
