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
            this.Hide(); //We hide our Main Form, it's still running at background and waiting to be shown again.We will use it.
            editMark myEditRecordForm = new editMark(); //Edit Form
            myEditRecordForm.Owner = this;  //We set New Edit Form's owner as this mainForm to access its lstMarks(listBox).
            myEditRecordForm.ShowDialog();
        }
    }
    
