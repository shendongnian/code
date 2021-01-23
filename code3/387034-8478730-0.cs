    private void customerInformationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (Customers.SelectedItems.Count != 0)
        {
            var myformmessagedialog = new MessageBoxForm;
            myformmessagedialog.Customers = Customers;
            if (myformmessagedialog.ShowDialog() == DialogResult.OK)
            {
              Customers = myformmessagedialog.Customers;
            }
        }
    }
