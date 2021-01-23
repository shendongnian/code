    private void _tm_Elapsed(object sender, ElapsedEventArgs e)
    {
        ((Timer) sender).Enabled = false;
        this.Dispatcher.Invoke(new Action(ChangeContent), null);
        //MessageBox.Show("ok");
    }
    
