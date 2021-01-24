    <Button x:Name="button1" Content="Button 1">
        <Button.Visibility>
            <Binding Path="IsButton1Visible">
                <Binding.Converter>
                    <local:BooleanToVisibilityNegationConverter />
                </Binding.Converter>
            </Binding>
        </Button.Visibility>
    </Button>
