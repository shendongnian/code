    <Style TargetType="{x:Type ButtonBase}" 
           x:Key="NonBlinkingButtonBase">
        <Setter Property="Control.Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type ButtonBase}">
                    <mwt:ButtonChrome Background="{TemplateBinding Panel.Background}" 
                                      BorderBrush="{TemplateBinding Border.BorderBrush}" 
                                      RenderDefaulted="False" 
                                      RenderMouseOver="{TemplateBinding UIElement.IsMouseOver}" 
                                      RenderPressed="{TemplateBinding ButtonBase.IsPressed}" 
                                      Name="Chrome" 
                                      SnapsToDevicePixels="True">
                        <ContentPresenter RecognizesAccessKey="True" 
                                          Content="{TemplateBinding ContentControl.Content}" 
                                          ContentTemplate="{TemplateBinding ContentControl.ContentTemplate}" 
                                          ContentStringFormat="{TemplateBinding ContentControl.ContentStringFormat}" 
                                          Margin="{TemplateBinding Control.Padding}" 
                                          HorizontalAlignment="{TemplateBinding Control.HorizontalContentAlignment}" 
                                          VerticalAlignment="{TemplateBinding Control.VerticalContentAlignment}" 
                                          SnapsToDevicePixels="{TemplateBinding UIElement.SnapsToDevicePixels}" />
                    </mwt:ButtonChrome>
                    <ControlTemplate.Triggers>
                        <Trigger Property="UIElement.IsKeyboardFocused" Value="True">
                            <Setter Property="mwt:ButtonChrome.RenderDefaulted" TargetName="Chrome" Value="True" />
                        </Trigger>
                        <Trigger Property="ToggleButton.IsChecked" Value="True">
                            <Setter Property="mwt:ButtonChrome.RenderPressed" TargetName="Chrome" Value="True" />
                        </Trigger>
                        <Trigger Property="UIElement.IsEnabled" Value="False">
                            <Setter Property="TextElement.Foreground">
                                <Setter.Value>
                                    <SolidColorBrush>
                                        #FFADADAD</SolidColorBrush>
                                </Setter.Value>
                            </Setter>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
