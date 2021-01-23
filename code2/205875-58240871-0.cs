    private void Button1_Click(object sender, EventArgs e)
    {
        NewForm newForm = new NewForm();    //Create the New Form Object
        this.Hide();    //Hide the Old Form
        newForm.ShowDialog();    //Show the New Form
        this.Close();    //Close the Old Form
    }
