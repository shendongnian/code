    <Page.Resources>
            <Style TargetType="RichEditBox">
                ......
                <Setter Property="SelectionFlyout" Value="{StaticResource TextControlCommandBarSelectionFlyout}"/>
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="RichEditBox">
                            <Grid>
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="Auto"/>
                                    <RowDefinition Height="*"/>
                                    <RowDefinition Height="Auto"/>
                                </Grid.RowDefinitions>
                                <VisualStateManager.VisualStateGroups>
                                    ......
                                </VisualStateManager.VisualStateGroups>
                                ......
                                <Border x:Name="BorderElement" Background="{TemplateBinding Background}" BorderThickness="{TemplateBinding BorderThickness}" BorderBrush="{TemplateBinding BorderBrush}" CornerRadius="{TemplateBinding CornerRadius}" MinHeight="0" MinWidth="{ThemeResource TextControlThemeMinWidth}" Grid.RowSpan="1" Grid.Row="1"/>
                                ......
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Page.Resources>
