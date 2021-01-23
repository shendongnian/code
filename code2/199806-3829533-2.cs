        <Window.Resources>
        <Style TargetType="{x:Type ComboBoxItem}">
            <Setter Property="Control.Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type ComboBoxItem}">
                        <Border Background="{TemplateBinding Background}">
                            <Grid>
                                <Grid.RowDefinitions>
                                    <RowDefinition />
                                    <RowDefinition />
                                </Grid.RowDefinitions>
                                <Border Margin="2" Grid.Row="0" Background="Azure" />
                                <ContentPresenter />
                            </Grid>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsMouseOver" Value="True">
                                <Setter Property="Background" Value="Green" />
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
