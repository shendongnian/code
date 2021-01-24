        int n = dataGridView1.Rows.Add();
        string val;
        if(radioAppointment.checked==true){
        val=radioAppointment.Text;
        }
    if(radioTask.checked==true){
        val=radioTask.Text;
        }
        dataGridView1.Rows[n].Cells[0].Value = val;
        dataGridView1.Rows[n].Cells[1].Value = textLocation.Text;
        dataGridView1.Rows[n].Cells[2].Value = dateTimePicker1.Text;
