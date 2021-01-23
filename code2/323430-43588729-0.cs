    public abstract class BaseModel : DependencyObject 
    
    {
    ...
    }
    
    public class MainModel : BaseModel
    
    {
    
    public bool ShowLabel
    
    {
        get{ return (bool)GetValue(ShowLabelProperty); }
        set{ SetValue(ShowLabelProperty, value) }
    }
    
    public static readonly DependencyProperty ShowLabelProperty =
    
        DependencyProperty.Register("ShowLabel",typeof(bool), typeof(MainModel), new PropertyMetadata(false));
    
    }
