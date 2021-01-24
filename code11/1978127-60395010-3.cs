    <Button x:Name="button1" Content="Button 1">
        <Button.Visibility>
            <Binding Path="IsButton1Visible">
                <Binding.Converter>
                    <BooleanToVisibilityConverter />
                </Binding.Converter>
            </Binding>
        </Button.Visibility>
    </Button>
    <Button x:Name="button2" Content="Button 2">
        <Button.Style>
            <Style TargetType="Button" BasedOn="{StaticResource {x:Type Button}}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsVisible, ElementName=button1}" Value="True">
                        <Setter Property="Visibility" Value="Collapsed" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Button.Style>
    </Button>
