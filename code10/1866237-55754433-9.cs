    private void btnSubmit_Click(object sender, EventArgs e)
    {
        string data = txtStudentID.Text + ":" + txtMark.Text;
        string[] parts = data.Split(':');
        Form1 mainForm = (Form1)this.Owner; //We get our hidden owner's REFERENCE to mainForm object.
        for (int i = 0; i < mainForm.lstMarks.Items.Count; i++) //loops mainForm.lstMarks.Items.Count
        {
            string[] item = mainForm.lstMarks.Items[i].ToString().Split(':'); //We test all of items one by one.
            if (item[0] == ModuleData.s_id) //if listbox's current item's ID part equals to our static ModuleData.s_id
                mainForm.lstMarks.Items[i] = data;  //Set new data.
        }
        mainForm.Show(); //We show our old Main Form which we hided before.
        this.Close();
    }
