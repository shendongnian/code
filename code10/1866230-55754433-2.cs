    public Form1()
    {
        InitializeComponent();
        lstMarks.Items.Add("1:Bulutay"); //I don't know your list.This is my guess.
        lstMarks.Items.Add("2:Person2"); //
        lstMarks.Items.Add("3:Person3"); //
        lstMarks.Items.Add("4:Person4"); //
    }
    private void btnUpdate_Click(object sender, EventArgs e)
    {
        string[] s_rec_arr;
        if (lstMarks.SelectedIndex == -1)
        {
            MessageBox.Show("please select a student");
        }
        else
        {
            ModuleData.s_rec = lstMarks.SelectedItem.ToString();
            s_rec_arr = lstMarks.SelectedItem.ToString().Split(':');
            ModuleData.s_id = s_rec_arr[0];
            ModuleData.s_mark = s_rec_arr[1];
            this.Hide();
            editMark myEditRecordForm = new editMark();
            myEditRecordForm.Owner = this;  //We set new form's owner as this mainForm for access its lstMarks.
            myEditRecordForm.ShowDialog();
        }
    }
    
