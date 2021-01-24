xml
<Application ...>
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="ms-appx:///Kinopub/UI/Utilities/resource_file_name.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
2. Add an `AppBarButton` named *LikeButton* to your `ControlTemplate` like this:
xml
<CommandBar x:Name="MediaControlsCommandBar" ...>
    ...
    <AppBarButton x:Name="LikeButton"
                  Icon="Like"
                  Style="{StaticResource AppBarButtonStyle}"
                  MediaTransportControlsHelper.DropoutOrder="3"
                  VerticalAlignment="Center"
                  />
    ...
</CommandBar>
Best regards.
