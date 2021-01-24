    public class CustomShellRenderer : ShellRenderer
	{
		public CustomShellRenderer(Context context) : base(context)
		{
		}
		protected override IShellToolbarAppearanceTracker CreateToolbarAppearanceTracker()
		{
			return new CustomShellToolbarAppearanceTracker(this);
		}
	}
    internal class CustomShellToolbarAppearanceTracker : IShellToolbarAppearanceTracker
    {
        private CustomShellRenderer customShellRenderer;
        public CustomShellToolbarAppearanceTracker(CustomShellRenderer customShellRenderer)
        {
            this.customShellRenderer = customShellRenderer;
        }
        public void Dispose()
        {
        }
        public void ResetAppearance(Toolbar toolbar, IShellToolbarTracker toolbarTracker)
        {
        }
        public void SetAppearance(Toolbar toolbar, IShellToolbarTracker toolbarTracker, ShellAppearance appearance)
        {
            toolbar.SetBackgroundColor(Android.Graphics.Color.Green);
            var viewParent = (Android.Support.Design.Widget.AppBarLayout)toolbar.Parent;            
            viewParent.SetElevation(0.0f);
        }
    }
