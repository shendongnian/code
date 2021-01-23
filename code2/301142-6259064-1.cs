    public void button1_Click(object sender, EventArgs e)
    {
        string departmentName = "IT";
        Form2 frm2 = new Form2();
        frm2.MyProperty = departmentName;
        frm2.Show();
        this.Hide();
    }
