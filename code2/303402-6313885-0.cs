    Form secondForm;//create a global var to save the pointer of the second application
    private void Button1_Click(object sender, EventArgs e)
    {
        if (secondForm == null || secondForm.IsDisposed)
        {
            secondForm = new Form2();
            secondForm.Visible = true;
        }
        else
        {
            secondForm.Visible = true;
        }
    }
