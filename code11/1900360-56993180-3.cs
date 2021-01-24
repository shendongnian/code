    private async void scanBtn_Click (object sender, RoutedEventArgs e)
    {
        while(someCondition)
        {
            InfoTxt.Text = "[ WAITING FOR PROCESS TO OPEN ]";
            var name=pName.Text;
            var p=await Task.Run(()=>SeekProcName(name));
            if (p!=null)
            {
                InfoTxt.Text = "[ FOUND ]";
            }
            await Task.Delay(1000);
        }
    }
