    List<string> txtlist = new List<string>();
    for (int i = 0; i < 16; i++)
    {
       string test = command.Get(appendCommand);
       txtlist.Add(test);
    }
    
    txt_1.Text = txtlist.ElementAt(0);  
    txt_2.Text = txtlist.ElementAt(1); 
    txt_3.Text = txtlist.ElementAt(2);
    txt_4.Text = txtlist.ElementAt(3);
    ...
    txt_4.Text = txtlist.ElementAt(15);
