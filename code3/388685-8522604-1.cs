    Computer MyComputer = new MyComputer();
    MyComputer.OnlineChanged += MyComputer_OnlineChanged;
    
    void MyComputer_OnlineChanged(object sender, EventArgs e)
    {
        Computer c = (Computer)c;
        MessageBox.Show("New value is " + c.Online.ToString());
    }
