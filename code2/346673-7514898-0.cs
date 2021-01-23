	public class MinimizableRibbon : Ribbon
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            RibbonTabHeaderItemsControl tabItems = this.FindName("TabHeaderItemsControl") as RibbonTabHeaderItemsControl;
            
            int lastClickTime = 0;
            if (tabItems != null)
                tabItems.PreviewMouseDown += (_, e) =>
                    {
                        // A continuous click was made (>= 2 clicks minimizes the control)
                        if (Environment.TickCount - lastClickTime < 300)
                            // here the control should be minimized
                            if (!IsMinimizable)
                                IsMinimized = false;
                        lastClickTime=Environment.TickCount;
                    };
        }
        
        public bool IsMinimizable { get; set; }
    }
