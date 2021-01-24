    private async void scanBtn_Click (object sender, RoutedEventArgs e)
    {
        InfoTxt.Text = "[ WAITING FOR PROCESS TO OPEN ]";
        var p=await Task.Run(()=>SeekProcName(pName.Text));
        if (p!=null)
        {
            InfoTxt.Text = "[ FOUND ]";
        }
    }
