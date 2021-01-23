    if (myTestForm != null)
    {
       MessageBox.ShowDialog("Sorry, you already have a TestForm open!");
    }
    else
    {
       myTestForm = new TestForm();
       myTestForm.FormClosing += myTestForm_FormClosing;
       myTestForm.MdiParent = this;
       myTestForm.Show();
    }
