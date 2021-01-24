<Window.Resources>
        <DataTemplate x:Key="LogDataTemplate">
            <StackPanel Orientation="Horizontal">
                
                <ContentControl Name="Indicator" Width="8" Height="8" Margin="0,0,5,0" HorizontalAlignment="Center"
                                >
                    <ContentControl.Resources>
                        <DataTemplate x:Key="TemplateError">
                            <ContentControl Content="{StaticResource Triangle}" Foreground="{StaticResource BaseRed}"/>
                        </DataTemplate>
                        <DataTemplate x:Key="TemplateWarning">
                            <ContentControl Content="{StaticResource Triangle}" Foreground="{StaticResource BaseYellow}"/>
                        </DataTemplate>
                        <DataTemplate x:Key="TemplateInformation">
                            <ContentControl Content="{StaticResource CircleFull}" Foreground="{StaticResource BaseGreen}"/>
                        </DataTemplate>
                        <DataTemplate x:Key="TemplateDefault">
                            <ContentControl Content="{StaticResource CircleBorderOnly}" Foreground="Gray"/>
                        </DataTemplate>
                        <DataTemplate x:Key="TemplateNull"/>
                    </ContentControl.Resources>
                    
                    <ContentControl.Style>
                        <Style TargetType="{x:Type ContentControl}">
                            <Setter Property="ContentTemplate" Value="{StaticResource TemplateDefault}" />
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding sMessageType}" Value="Error">
                                    <Setter Property="ContentTemplate" Value="{StaticResource TemplateError}" />
                                    <Setter Property="LayoutTransform">
                                        <Setter.Value>
                                            <RotateTransform Angle="180"/>
                                        </Setter.Value>
                                    </Setter>
                                </DataTrigger>
                                <DataTrigger Binding="{Binding sMessageType}" Value="Information">
                                    <Setter Property="ContentTemplate" Value="{StaticResource TemplateInformation}" />
                                </DataTrigger>
                                <DataTrigger Binding="{Binding sMessageType}" Value="Warning">
                                    <Setter Property="ContentTemplate" Value="{StaticResource TemplateWarning}" />
                                </DataTrigger>
                                <!-- Used to avoid to display a gray circle when nothing to display -->
                                <DataTrigger Binding="{Binding sMessageType}" Value="{x:Null}">
                                    <Setter Property="ContentTemplate" Value="{StaticResource TemplateNull}" />
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </ContentControl.Style>
                </ContentControl>
                <TextBlock Text="{Binding sMessage}" Style="{StaticResource DefaultLogTextBlockStyle}" />
            </StackPanel>
        </DataTemplate>
</Window.Resources>
