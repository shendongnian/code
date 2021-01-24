    <Window.Resources>
        <Style TargetType ="{x:Type ToggleButton}" x:Key="toggle">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type ToggleButton}">                        
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsChecked" Value="True">
                                <Setter Property="Background">
                                    <Setter.Value>
                                        <SolidColorBrush>
                                            <SolidColorBrush.Color>Beige</SolidColorBrush.Color>
                                        </SolidColorBrush>
                                    </Setter.Value>
                                </Setter>
                            </Trigger>
                            <Trigger Property="IsChecked" Value="False">
                                <Setter Property="Background">
                                    <Setter.Value>
                                        <SolidColorBrush>
                                            <SolidColorBrush.Color>Brown</SolidColorBrush.Color>
                                        </SolidColorBrush>
                                    </Setter.Value>
                                </Setter>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>            
            </Setter>
        </Style>
    </Window.Resources>
    <Grid>
        <ToggleButton Style="{DynamicResource toggle}" Width="150" Height="150"/>
    </Grid>
