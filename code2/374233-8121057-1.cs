    int val = 0;
    bool res = Int32.TryParse(txtbox1.Text, out val);
    if(res == true && val > -1 && val < 101)
    {
        // add record
    }
    else
    {
        MessageBox.Show("Please input 0 to 100 only.");
        return;
    }
