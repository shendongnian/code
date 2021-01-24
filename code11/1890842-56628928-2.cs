       namespace DipsDemoXaml.Custom.Renderer
    {
       public class CustomWebView : WebView
       {
        public static readonly BindableProperty UriProperty =
           
 
 
       BindableProperty.Create(nameof(Uri),typeof(string),
        typeof(CustomWebView),default(string)) 
       ;
        
        public string Uri
        {
            get => (string) GetValue(UriProperty);
            set => SetValue(UriProperty, value);
        }
    }
