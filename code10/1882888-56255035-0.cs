        internal static MainWindow _MainWindow; 
        internal string SerialData
        {
            get => SerialDataTextBox.Content.ToString();
            set { this.Dispatcher.Invoke((() => { SerialDataTextBox.Content = value; })); }
        }
