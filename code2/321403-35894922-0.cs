     public class CustomRibbonApplicationMenu : System.Windows.Controls.Ribbon.RibbonApplicationMenu
        {
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
    
                System.Windows.DependencyObject obj = this.GetTemplateChild("PART_AuxiliaryPaneContentPresenter");
    
                System.Windows.Controls.ContentPresenter c = obj as System.Windows.Controls.ContentPresenter;
    
                ((System.Windows.Controls.Grid)((System.Windows.Controls.Border)c.Parent).Parent).ColumnDefinitions[2].Width = System.Windows.GridLength.Auto;
            }
        }
