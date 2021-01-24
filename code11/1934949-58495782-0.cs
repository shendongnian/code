    public class MainTabbedPageRenderer : TabbedRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
              this.ShouldSelectViewController = ShouldSelectViewControllerHandler;
        }
 
        bool ShouldSelectViewControllerHandler(UITabBarController tabBarController, UIViewController viewController)
        {
            return false;
        }
    }
