    DateTime sd=Convert.ToDateTime("2/2/2007");
    DateTime ed =Convert.ToDateTime("2/2/2009");
    if ((sd<=Convert.ToDateTime(nTextBox1.Text)) && (Convert.ToDateTime(nTextBox1.Text<=ed))
    {
    MessageBox.Show("In Range");
    }
    else
    {
    MessageBox.Show("Not In Range");
    }
