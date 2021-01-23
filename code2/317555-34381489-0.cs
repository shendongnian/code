        private void mnuMyForm_Click(object sender, EventArgs e) // click to open MyForm
        {
            foreach (Form item in this.MdiChildren) // check all opened forms
            {
                if (item.Name == "MyFormName") // check by form name if it's opened
                {
                    item.BringToFront(); // bring it front
                    return; //exit
                }
            }
            // if MyForm is not opened
            // you know what it is
            MyForm frm = new MyForm();
            frm.MdiParent = this;
            frm.Show();
        }
