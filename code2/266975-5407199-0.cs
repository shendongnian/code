    bool IsOpen = false;
    foreach (Form f in Application.OpenForms)
    {
        if (f.Text == "Form2") //  Name of the Form
        {
            IsOpen = true;
            f.Focus();
            break;
        }
    }
    if (IsOpen == false)
    {
        Form2 f2 = new Form2();
        f2.MdiParent = this;
        f2.Show();
    }
