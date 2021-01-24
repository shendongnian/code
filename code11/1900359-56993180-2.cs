    private async void scanBtn_Click (object sender, RoutedEventArgs e)
    {
        InfoTxt.Text = "[ WAITING FOR PROCESS TO OPEN ]";
        //Read the textbox contets *before* starting the task
        var name=pName.Text;
        var p=await Task.Run(()=>SeekProcName(name));
        if (p!=null)
        {
            InfoTxt.Text = "[ FOUND ]";
        }
    }
