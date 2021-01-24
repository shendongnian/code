    public class CustomListViewRenderer : ListViewRenderer
    {
        public CustomListViewRenderer(Android.Content.Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var listview = this.Control as Android.Widget.ListView;
                listview.NestedScrollingEnabled = true;
            }
        }
    }
