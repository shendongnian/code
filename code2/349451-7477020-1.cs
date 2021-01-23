      public MainWindow()
      {
         InitializeComponent();
         treeView.ItemsSource = new[] 
         { 
            new TestClass { Title = "Google", Url = "http://www.google.com" }, 
            new TestClass { Title = "Microsoft", Url = "http://www.microsoft.com" },
            new TestClass{ Title="Netflix", Url="http://www.netflix.com" }
         };
      }
      private void treeViewItem_DragOver(object sender, DragEventArgs e)
      {
      }
      private void treeViewItem_Drop(object sender, DragEventArgs e)
      {
      }
      private void treeViewItem_MouseMove(object sender, MouseEventArgs e)
      {
      }
