    <Button ...>
        <Button.Resources>
            <Style TargetType="Microsoft_Windows_Themes:ButtonChrome">
                <EventSetter Event="Loaded" Handler="ButtonChrome_Loaded"/>
            </Style>
        </Button.Resources>
    void ButtonChrome_Loaded(object sender, RoutedEventArgs e)
    {
        ButtonChrome buttonChrome = sender as ButtonChrome;
        if (buttonChrome != null)
        {
            buttonChrome.RenderMouseOver = false;
            buttonChrome.RenderPressed = false;
        }
    }
