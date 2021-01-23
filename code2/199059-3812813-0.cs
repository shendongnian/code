    private void radioButton1_CheckedChanged(object sender, EventArgs e){
        RadioButton radioSender = sender as RadioButton;
        if (radioSender != null){
            sF1411BindingSource.Sort = radioSender.Tag.ToString();
            sF1411BindingSource.MoveFirst();
            //Set the find label to display the new find column
            groupBox4.Text = "Find - " + radioSender.Tag.ToString() + ":";
            //Store the sort column name in lblFind's Tag property
            groupBox4.Tag = radioSender.Tag.ToString();
            textBox1.ReadOnly = false;
        }
    }
