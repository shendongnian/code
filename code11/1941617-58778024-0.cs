        public DirectoryContentList()
        {
            InitializeComponent();
            Application.Current.MainWindow.SizeChanged += ResizeNameColumn;
        }
        private void ResizeNameColumn(object sender, SizeChangedEventArgs args)
        {
            var newWidth = Application.Current.MainWindow.ActualWidth - (TypeColumn.Width + SizeColumn.Width + 290);
            NameColumn.Width = newWidth > 0 ?  newWidth :  0; //Cannot set negative value to the column width
        }
Firstly try to name columns in xaml file, then change the width manually in code behind.
