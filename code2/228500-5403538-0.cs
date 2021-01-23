    private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        //Execute the command related to the doubleclick, in my case Edit
        (this.DataContext as VmHome).EditAppCommand.Execute(null);
    }
