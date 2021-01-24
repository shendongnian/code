    public class MyListViewRenderer : ListViewRenderer
    {
        Context ctx;
        public MyListViewRenderer(Context context) : base(context)
        {
            ctx = context;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                //var listView = Control as Android.Widget.ListView;
                Drawable drawable = Resources.GetDrawable(Resource.Drawable.DashedLines);               
                Control.DividerHeight = 20;
                Control.Divider = drawable;
                Control.SetLayerType(LayerType.Software,null);
            }
        }
    }
