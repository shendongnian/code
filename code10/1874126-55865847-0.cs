public partial class IVI_Display : ContentPage
{
    public IVI_DisplayViewModel ViewModel { get; set; }
       public IVI_Display()
       {
            ViewModel = new IVI_DisplayViewModel();
            ...
            BindingContext = ViewModel;
       }    
}
public class IVI_DisplayViewModel
{
    public object Coordinates { get; set; }
    ...
}
</pre>
