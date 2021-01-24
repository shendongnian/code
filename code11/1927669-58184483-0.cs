        <Style TargetType="Button">
            <Setter Property="Background" Value="Red"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Border Name="border" 
                                BorderThickness="1"
                                Padding="4,2" 
                                BorderBrush="DarkGray" 
                                CornerRadius="3" 
                                Background="{TemplateBinding Background}">
                            <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" />
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsMouseOver" Value="True">
                                <Setter TargetName="border" Property="BorderBrush" Value="Black" />
                            </Trigger>
                            <Trigger Property="IsPressed" Value="True">
                                <Trigger.EnterActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <ColorAnimation Storyboard.TargetProperty="(Button.Background).(SolidColorBrush.Color)" 
                                                To="Orange" 
                                                Duration="0:0:1" 
                                                AutoReverse="True" 
                                                FillBehavior="Stop" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.EnterActions>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </ResourceDictionary>
