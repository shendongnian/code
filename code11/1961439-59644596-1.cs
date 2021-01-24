    <ContentControl Margin="2 0 6 0" Width="20" Height="20">
        <ContentControl.Style>
            <Style>
                <Setter Property="ContentControl.Content">
                    <Setter.Value>
                        <TextBlock Text="Original"/>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <Trigger Property="UIElement.IsMouseOver" Value="True">
                        <Setter Property="ContentControl.Content">
                            <Setter.Value>
                                <Viewbox Stretch="Uniform">
                                    <TextBlock Text="Changed"/>
                                </Viewbox>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </ContentControl.Style>
    </ContentControl>
