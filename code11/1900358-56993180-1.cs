    private async void scanBtn_Click (object sender, RoutedEventArgs e)
    {
        while(someCondition)
        {
            InfoTxt.Text = "[ WAITING FOR PROCESS TO OPEN ]";
            var p=await Task.Run(()=>SeekProcName(pName.Text));
            if (p!=null)
            {
                InfoTxt.Text = "[ FOUND ]";
            }
            await Task.Delay(1000);
        }
    }
