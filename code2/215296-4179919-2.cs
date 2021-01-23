        public bool CloseAllowed { get; set; }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (!CloseAllowed) {
                this.Visibility = System.Windows.Visibility.Hidden;
                e.Cancel = true;
            }
        }
