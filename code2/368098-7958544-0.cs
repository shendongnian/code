        private void button1_Click(object sender, RoutedEventArgs e)
        {
            using (dynamic SWbemLocator = AutomationFactory.CreateObject("WbemScripting.SWbemLocator"))
            {
                SWbemLocator.Security_.ImpersonationLevel = 3;
                SWbemLocator.Security_.AuthenticationLevel = 4;
                dynamic IService = SWbemLocator.ConnectServer(".", @"root\cimv2");
                dynamic QueryResults = IService.ExecQuery(@"SELECT * FROM Win32_Process");
                dynamic t = QueryResults.Count;
                for (int i = 0; i < t; i++)
                {
                    dynamic p = QueryResults.ItemIndex(i);
                    MessageBox.Show(p.name );
                }
            } 
        }
