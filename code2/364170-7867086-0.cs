    int a;
    int b;
    if (!int.TryParse(subjectsLabel1.Text, out a))
    {
        MessageBox.Show("please enter a valid integer in subjectsLabel1");
    } 
    else if (!int.TryParse(internetLabel1.Text, out b))
    {
        MessageBox.Show("please enter a valid integer in internetLabel1");
    }
    else
    {
        // the parsing went fine => we could safely use the a and b variables here
        int total = a + b;
        label1.Text = total.ToString();
    }
