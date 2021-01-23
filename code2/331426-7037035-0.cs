    if (myTestForm != null)
    {
       MessageBox.ShowDialog("Sorry, you already have a TestForm open!");
    }
    else
    {
       myTestForm = new TestForm();
       myTestForm.Closing += myTestForm_Closing;
       myTestForm.MdiParent = this;
       myTestForm.Show();
    }
