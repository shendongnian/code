public interface IMyView
{
    IMyViewModel ViewModel { get; set; }
}
public interface IMyViewModel
{
}
In the module or app.cs, in the method RegisterTypes you should register these.
containerRegistry.Register<IMyView, MyView>();
containerRegistry.Register<IMyViewModel, MyViewModel>();
You must implement IMyView interface in your MyView.cs class.
public partial class MyView : UserControl, IMyView
{
    public MyView(IMyViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
    }
    public IMyViewModel ViewModel 
    {
        get => DataContext as IMyViewModel;
        set => DataContext = value;
    }
}
After you could use it:
public void OnInitialized(IContainerProvider containerProvider)
{
    var regionManager = containerProvider.Resolve<IRegionManager>();
    var firstView = containerProvider.Resolve<IMyView>();
    
    regionManager.AddToRegion(RegionNames.MainRegion, firstView);
}
**In such case you shouldn't use ViewModelLocator.AutoWireViewModel in your view.**
