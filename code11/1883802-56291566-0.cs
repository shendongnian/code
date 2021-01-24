    public class MyWebView : WebView
    {
      public static readonly BindableProperty UrlProperty = BindableProperty.Create(
        propertyName: "Url",
        returnType: typeof(string),
        declaringType: typeof(MyWebView),
        defaultValue: default(string));
     public string Url
     {
        get { return (string)GetValue(UrlProperty); }
        set { SetValue(UrlProperty, value); }
     }
    }
