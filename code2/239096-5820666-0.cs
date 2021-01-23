        Application.Current.MainWindow = this;
        var Query = System.Diagnostics.Process.GetProcessesByName("ProcessName");
        if (Query.Any())
        {
            Query.FirstOrDefault().Refresh();
            MessageBox.Show(Query.FirstOrDefault().MainWindowHandle.ToInt32().ToString());
        }
