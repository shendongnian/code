    public partial class WebBrowserControl : Form
    {
         private String url;
    
         [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
         public static extern bool InternetSetCookie(string lpszUrlName, string    lbszCookieName, string lpszCookieData);
    
         public WebBrowserControl(String path)
         {
              this.url = path;
              InitializeComponent();
    
              // set cookie
              InternetSetCookie(url, "JSESSIONID", Globals.ThisDocument.sessionID); 
    
              // navigate
              webBrowser.Navigate(url); 
         }
    }
