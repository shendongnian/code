    [assembly: ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]
    
    namespace yourNameSpace
    {
        public class CustomSwitchRenderer : SwitchRenderer
        {
            protected override void OnElementChanged (ElementChangedEventArgs<Switch> e)
            {
                base.OnElementChanged (e);
    
                if (Control != null) 
                {
                     //change color
                    Control.OnTintColor = UIColor.FromRGB (204, 153, 255);
                }
             }
        }
    }
