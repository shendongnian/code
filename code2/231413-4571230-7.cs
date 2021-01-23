    private void btnOkay_Click(object sender, EventArgs e)
    {
        //string name;
        name = tbxName.Text;
        Form1 ict = new Form1();
        if (name == "")
        {
            MessageBox.Show("Please Enter Your Name!");
        }
        else
        {
        ict._nameProcessed = name;
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
        }
    }
