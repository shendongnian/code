        List<Uri> HistoryStack;
        int HistoryStack_Index;
        bool fromHistory;
        // Constructor
        public HelpView()
        {
            InitializeComponent();
            HistoryStack = new List<Uri>();
            HistoryStack_Index = 0;
            fromHistory = false;
            webView.Navigated += new EventHandler<System.Windows.Navigation.NavigationEventArgs>(webView_Navigated);
            updateNavButtons();
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (HistoryStack_Index > 1)
            {
                HistoryStack_Index -= 1;
                fromHistory = true;
                webView.Navigate(HistoryStack[HistoryStack_Index-1]);
                updateNavButtons();
            }
        }
        private void forwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (HistoryStack_Index < HistoryStack.Count)
            {
                HistoryStack_Index += 1;
                fromHistory = true;
                webView.Navigate(HistoryStack[HistoryStack_Index-1]);
                updateNavButtons();
            }
        }
        private void updateNavButtons()
        {
            if (HistoryStack_Index > 1)
            {
                this.backButton.IsEnabled = true;
            }
            else
            {
                this.backButton.IsEnabled = false;
            }
            if (HistoryStack_Index < HistoryStack.Count)
            {
                this.forwardButton.IsEnabled = true;
            }
            else
            {
                this.forwardButton.IsEnabled = false;
            }
        }
        private void webView_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (!fromHistory)
            {
                if (HistoryStack_Index < HistoryStack.Count)
                {
                    HistoryStack.RemoveRange(HistoryStack_Index, HistoryStack.Count - HistoryStack_Index);
                }
                HistoryStack.Add(e.Uri);
                HistoryStack_Index += 1;
                updateNavButtons();
            }
            fromHistory = false;
        }
