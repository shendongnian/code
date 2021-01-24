    <Button x:Name="button1" Content="Button 1">
        <Button.Visibility>
            <Binding Path="IsButton1Visible">
                <Binding.Converter>
                    <BooleanToVisibilityConverter />
                </Binding.Converter>
            </Binding>
        </Button.Visibility>
    </Button>
