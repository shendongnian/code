xml
<ScrollViewer>
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>
        <Grid Background="Black" x:Name="MediaContainer">
            <MediaPlayerElement
                            ...
                            HorizontalAlignment="Center"/>
        </Grid>
        ...
    </Grid>
</ScrollViewer>
**xaml.cs**
csharp
public VideoPage()
{
    this.InitializeComponent();
    this.SizeChanged += Page_SizeChanged;
}
private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
{
    double height = e.NewSize.Height;
    MediaContainer.Height = height * 0.8;
}
Best regards.
