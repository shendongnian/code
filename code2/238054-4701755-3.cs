    public void Button1_Click(object sender, EventArgs e)
    {
      Form2 form2 = new Form2("Bob");      // Start with "Bob"
      form2.ShowDialog();                  // Dialog opens and user enters "John" and closes it
      MessageBox.Show(form2.TextBoxValue); // now the value is "John"
    }
