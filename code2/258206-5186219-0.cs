        private void btnAddChange_Document(object sender, RoutedEventArgs e)
        {
            System.Threading.ThreadStart start = delegate()
            {
                //do intensive work; on background thread
                string x = "";
                for (int i = 0; i <= 1000; i++)
                {
                    x += i.ToString();
                }
                //done doing work, send result to the UI thread
                Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, 
                    new Action<int>(changest));
            };
            //perform UI work before we start the new thread
            this.BusyIndicator_CompSelect.IsBusy = true;
            this.MainWindow_parent.BusyIndicator_MainWindow.IsBusy = true;
            t = "Creating document 1/2..";
            //create new thread, start it
            new System.Threading.Thread(start).Start();
        }
        public void changest(int x)
        {
            //show the result on the UI thread
            MessageBox.Show(x.ToString());
        }
