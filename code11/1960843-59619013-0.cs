    public class ExtendedEntryRender : EntryRenderer
        {
            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
    
                if (Control != null)
                {
                    Control.KeyPress += ((Entry)Element).OnTextChangeByUI;
    
    
                }
            }
        }
 
