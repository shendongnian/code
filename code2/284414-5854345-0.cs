     protected void FormView1_DataBound(object sender, EventArgs e)
    {
        if (FormView1.CurrentMode == FormViewMode.Insert)
        {
            TextBox dateadded = FormView1.FindControl("dateaddedTextBox") as TextBox;
            dateadded.Text = DateTime.Now.ToString("d");
        }
    }
