xaml
<i:Interaction.Triggers>
    <i:EventTrigger EventName="Loaded">
        <i:InvokeCommandAction Command="{Binding OnLoadedCommand}" />
    </i:EventTrigger>
</i:Interaction.Triggers>
<Grid>
    <DockPanel LastChildFill="True">
        <views:AdminNavView DockPanel.Dock="Top" Margin="5" />
        <ContentControl prism:RegionManager.RegionName="{x:Static core:RegionNames.AuthContentRegion}"  Margin="5" />
    </DockPanel>
</Grid>
ViewModel:
c#
public class AdminViewModel : BindableBase, IRegionMemberLifetime
{
    private readonly IRegionManager _regionManager;
    public AdminViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
        OnLoadedCommand = new DelegateCommand(OnLoaded);
    }
    public bool KeepAlive => false;
    public ICommand OnLoadedCommand { get; }
    public void OnLoaded()
    {
        _regionManager.RequestNavigate(RegionNames.AuthContentRegion, NavigationPaths.RailwayListPath);
    }
}
