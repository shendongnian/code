    using (var form = new frmImportContact())
    {
        var result = form.ShowDialog();
        if (result == DialogResult.OK)
        {
            string val = form.ReturnValue1;            //values preserved after close
            string dateString = form.ReturnValue2;
            //Do something here with these values
            //for example
            this.txtSomething.Text = val;
        }
    }
