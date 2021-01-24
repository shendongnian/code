<customViews:TaskLoaderView  
    Grid.Row="2"
    Style="{StaticResource SillyTaskLoader}"
    ViewModelLoader="{Binding SillyPeopleLoader}">
    <Grid ColumnSpacing="0" RowSpacing="0">
        <Grid.RowDefinitions>
            <RowDefinition 
                x:Name="SillyOfTheDayHeader" 
                Height="{StaticResource HeaderHeight}" />
            <RowDefinition Height="144" />
            <RowDefinition 
                x:Name="ListViewHeader" 
                Height="{StaticResource HeaderHeight}" />
            <!--  ItemHeight + VerticalMargin + VerticalPadding  -->
            <RowDefinition Height="176" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        <!--  ROW 0: Silly Of The Day Header  -->
        <Label 
            Grid.Row="0"
            Style="{StaticResource TextHeader}"
            Text="{loc:Translate SillyPeople_SillyOfTheDay}" />
        <!-- etc -->
    </Grid>
</customViews:TaskLoaderView>  
And the view model:
public class SillyPeopleVm : ANavigableViewModel  
{
    private readonly ISillyDudeService _sillyDudeService;
    public SillyPeopleVm(
        INavigationService navigationService, 
        ISillyDudeService sillyDudeService, 
        ErrorEmulator errorEmulator)
        : base(navigationService)
    {
        _sillyDudeService = sillyDudeService;
        InitCommands();
        SillyPeopleLoader = new 
            ViewModelLoader<ObservableCollection<SillyDudeVmo>>( 
                ApplicationExceptions.ToString, 
                SillyResources.Empty_Screen);
    }
    public ErrorEmulatorVm ErrorEmulator { get; }
    public SillyDudeVmo SillyOfTheDay { get; private set; }
    public ViewModelLoader<ObservableCollection<SillyDudeVmo>> 
        SillyPeopleLoader { get; }
    public override void Load(object parameter)
    {
        SillyPeopleLoader.Load(LoadSillyPeopleAsync);
    }
    private async Task<ObservableCollection<SillyDudeVmo>> LoadSillyPeopleAsync()
    {
        SillyOfTheDay = new SillyDudeVmo(
            await _sillyDudeService.GetRandomSilly(), GoToSillyDudeCommand);
        RaisePropertyChanged(nameof(SillyOfTheDay));
        return new ObservableCollection<SillyDudeVmo>(
            (await _sillyDudeService.GetSillyPeople())
                .Select(dude => 
                    new SillyDudeVmo(dude, GoToSillyDudeCommand)));
    }
}
https://www.sharpnado.com/taskloaderview-async-init-made-easy/
