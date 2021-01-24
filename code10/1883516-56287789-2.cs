     public partial class MainPage : ContentPage
        {
            public static string CurrentUrl { get; set; }
    
            public static MyWebView _webView;
    
            public static Grid grid;
    
            public static Button BackButton;
    
    
            public MainPage()
            {
    
                InitializeComponent();
    
                string CurrentUrl = "https://www.baidu.com/";
    
                _webView = new MyWebView()
                {
                    Source = CurrentUrl,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
    
    
                BackButton = new Button
                {
                    Text = "Go Back",
                    BackgroundColor = Color.FromHex("990000"),
                    TextColor = Color.White
                };
    
                grid = new Grid
                {
                     //...
                };
    
                grid.Children.Add(_webView, 0, 6, 0, 7);
    
    
                Content = grid;
    
                checkToShowButton();
    
                //Button click
                BackButton.Clicked += OnBackButtonClicked;
                void OnBackButtonClicked(object sender, EventArgs e)
                {
                    _webView.GoBack();        
    
                    checkToShowButton();
    
                    if (_webView.CanGoBack == false)
                    {
                        grid.Children.Remove(BackButton);
                    }
                }
            }
    
            //Check whther to show goBack button
            public static void checkToShowButton()
            {
    
                if ("https://www.baidu.com/".Equals(MainPage.CurrentUrl) || CurrentUrl == null || CurrentUrl == "")
                {
                    grid.Children.Remove(BackButton);
                }
                else
                {
    
                    if (grid != null)
                    {
                        grid.Children.Add(BackButton, 2, 4, 4, 6);
                    }
    
                }
            }
    
        }
    
        public class MyWebView : WebView { }
