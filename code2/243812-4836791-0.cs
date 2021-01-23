        private void AssignEventHandlers()
        {
            foreach (Window window in Application.Current.Windows)
            {
                //if (window != Application.Current.MainWindow)
                    window.KeyDown += new System.Windows.Input.KeyEventHandler(window_KeyDown);
            }
        }
        void window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            MessageBox.Show(e.Key.ToString());
        }
