    public class NavigationRenderer : PageRenderer
    {
        private CustomTitleView _titleView;
        public NavigationSearchRenderer(Context context) : base(context)
        {
    
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
    
            var navPage = Element as NavigationSearchPage;
            if (navPage == null)
                return;
    
            var activity = this.Context as FormsAppCompatActivity;
            if (activity == null)
                return;
    
            var toolbar = activity.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            _titleView= new TitleView(Context);
            toolbar.AddView(_titleView);
        }
    
    }
