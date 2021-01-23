    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        SqlCeConnection con = new SqlCeConnection("Data Source=|DataDirectory|\\Master.sdf");
        ThreadPool.QueueUserWorkItem(new WaitCallback((obj) =>
        {
            this.IsEnabled = false;
            try
            {
                con.Open();
                Dispatcher.Invoke(new Action(() =>
                {
                    MessageBox.Show("Database Connection Established");
                }));
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    MessageBox.Show("Database Connection Failed");
                }));
                throw;
            }
            finally
            {
                this.IsEnabled = true;
            }
        }));
    }
