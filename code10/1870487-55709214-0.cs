        namespace PageTest
        {
    
            public partial class MainWindow : Window
            {
                public MainWindow()
                {
                    InitializeComponent();
                    var page1 = new Page1();
                    page1.PageSwapRequested += Page1_PageSwapRequested;
                    FrameContent.Content = page1;
                }
    
                private void Page1_PageSwapRequested(object sender, EventArgs e)
                {
                    //TODO: swap pages and don't forget to remove Page1_PageSwapRequested event handler.
                    //page1.PageSwapRequested -= Page1_PageSwapRequested;
                }
            }
        }
    
        namespace PageTest
        {
    
            public partial class Page1 : Page
            {
                public event EventHandler PageSwapRequested;
                private void OnPageSwapRequested()
                {
                    this.PageSwapRequested?.Invoke(this, EventArgs.Empty);
                }
                public Page1()
                {
                    InitializeComponent();
                }
    
                private void BtnLoadPage2_Click(object sender, RoutedEventArgs e)
                {
                    OnPageSwapRequested();
                }
            }
        }
    
        namespace PageTest
        {
    
            public partial class Page2 : Page
            {
                public event EventHandler PageSwapRequested;
                private void OnPageSwapRequested()
                {
                    this.PageSwapRequested?.Invoke(this, EventArgs.Empty);
                }
                public Page2()
                {
                    InitializeComponent();
                }
    
                private void BtnLoadPage1_Click(object sender, RoutedEventArgs e)
                {
                    this.OnPageSwapRequested();
                }
            }
        }
