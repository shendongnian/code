    public class MyShellRenderer : ShellRenderer
    {
        protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection)
        {
            var renderer = base.CreateShellSectionRenderer(shellSection);
            if (renderer != null)
            {
                (renderer as ShellSectionRenderer).NavigationBar.SetBackgroundImage(UIImage.FromFile("monkey.png"), UIBarMetrics.Default);
            }
            return renderer;
        }
        protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
        {
            return new CustomTabbarAppearance();
        }
    }
    public class CustomTabbarAppearance : IShellTabBarAppearanceTracker
    {
        public void Dispose()
        {
        }
        public void ResetAppearance(UITabBarController controller)
        {
        }
        public void UpdateLayout(UITabBarController controller)
        {
            UITabBar myTabBar = controller.TabBar;
            foreach (var barItem in myTabBar.Items)
            {
                barItem.ImageInsets = new UIEdgeInsets(8, 0, 0, 0);
                //barItem.TitlePositionAdjustment = new UIOffset(10, 0);
            }
        }
    }
