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
            // MessageBox.Show(e.Key.ToString());
            if (System.Windows.Input.Keyboard.Modifiers == (System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt)
                && e.Key == System.Windows.Input.Key.O)
            {
                MessageBox.Show(System.Windows.Input.Keyboard.Modifiers.ToString() + " " + e.Key.ToString());
            }
        }
