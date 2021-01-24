    [assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(MyButtonRenderer))]
    namespace ButtonStyle.Droid
    {
    
    public class MyButtonRenderer : ButtonRenderer
    {
        public MyButtonRenderer(Context context) : base(context) { }
        protected override void 
        OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> args)
        {
            base.OnElementChanged(args);
            if (Control != null) SetColors();
        }
        protected override void OnElementPropertyChanged(object sender, 
        PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);
            if (args.PropertyName == nameof(Xamarin.Forms.Button.IsEnabled)) SetColors();
        }
        private void SetColors()
        {
            Control.SetTextColor(Element.IsEnabled ? Element.TextColor.ToAndroid() : 
            Android.Graphics.Color.Red);
            Control.SetBackgroundColor(Element.IsEnabled ? 
            Element.BackgroundColor.ToAndroid() : Android.Graphics.Color.Purple);
        }
     }
    }
