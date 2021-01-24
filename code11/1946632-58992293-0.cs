        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            string processname = System.IO.Path.GetFileNameWithoutExtension 
                (System.Reflection.Assembly.GetEntryAssembly().Location);
            if (processname != "OtherApplicationName")
                Close();
            else
                Application.Current.Shutdown();
        }
