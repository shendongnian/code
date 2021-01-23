    <!--...-->
    <Window.Resources>
            <BooleanToVisibilityConverter x:Key="B2VConv"/>
    </Window.Resources>
    <!--...-->
            <ItemsControl ItemsSource="{Binding Data}">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Vertical">
                            <ToggleButton x:Name="tbutton" Content="{Binding Title}">
                                <ToggleButton.Template>
                                    <ControlTemplate TargetType="ToggleButton">
                                        <TextBlock Text="{TemplateBinding Content}"/>
                                    </ControlTemplate>
                                </ToggleButton.Template>
                            </ToggleButton>
                            <Border Visibility="{Binding ElementName=tbutton, Path=IsChecked,Converter={StaticResource B2VConv}}">
                                <TextBlock Text="{Binding Description}"/>
                            </Border>
                        </StackPanel>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
     <!--...-->
