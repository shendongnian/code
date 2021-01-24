    [assembly: ExportRenderer(typeof(myScrollView), typeof(MyScrollviewRender))]
    
    namespace App308.iOS
    {
        class MyScrollviewRender : ScrollViewRenderer
        {
            protected override void OnElementChanged(VisualElementChangedEventArgs e)
            {
                base.OnElementChanged(e);
    
                if (e.OldElement != null || Element == null)
                {
                    return;
                }
    
                if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
                {
                    this.ContentInsetAdjustmentBehavior = UIScrollViewContentInsetAdjustmentBehavior.Never;
                }
            }
        }
    }
