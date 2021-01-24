    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var browser = new myWebView();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"<html><body>
                            <h1 onclick=""window.location='Navigation://yahoo'"">Xamarin.Forms</h1>
                            </br> </br></br>
                            <a href=""Navigation://google""> Click on me</a>
                            </br> </br></br>
                            <p>Welcome to WebView Test Navigation.</p>
                            </body>
                            </html>";
            browser.Source = htmlSource;
            Content = browser;
            browser.Navigated += Browser_Navigated;
            MessagingCenter.Subscribe<Object,string>(this, "shouldLoadUrl", (sender, arg) => {
                // do something whenever the "shouldLoadUrl" message is sent
                //arg is the url 
                Console.WriteLine(arg);
                myAction(arg);
            });
        }
        private void Browser_Navigated(object sender, WebNavigatedEventArgs e)
        {
            string url = e.Url;
            if (url.StartsWith("file:"))
            {
                return;
            }
            myAction(url);
        }
        public void myAction(string url) {
            if (url == "google")
            {
                //do some action
            }
            else if (url == "yahoo")
            {
                //do some action
            }
        }
    }
    public class myWebView : WebView {
    }
