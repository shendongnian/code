    public void Button1_Click(object sender, EventArgs e)
    {
      Form2 form2 = new Form2();
      form2.ShowDialog();
      MessageBox.Show(form2.TextBoxValue); // here's where you reference the property
    }
