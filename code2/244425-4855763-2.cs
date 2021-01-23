    <ItemsControl ItemsSource="{Binding Data}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <DataTemplate.Resources>
                    <BooleanToVisibilityConverter x:Key="B2VConv"/>
                </DataTemplate.Resources>
                <StackPanel Orientation="Vertical">
                    <ToggleButton x:Name="tbutton" Content="{Binding Title}">
                        <ToggleButton.Template>
                            <ControlTemplate TargetType="ToggleButton">
                                <ContentPresenter/>
                            </ControlTemplate>
                        </ToggleButton.Template>
                        <ToggleButton.ContentTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding}"/>
                            </DataTemplate>
                        </ToggleButton.ContentTemplate>
                    </ToggleButton>
                    <TextBlock Text="{Binding Description}"
                               Visibility="{Binding ElementName=tbutton, Path=IsChecked,Converter={StaticResource B2VConv}}">
                    </TextBlock>
                </StackPanel>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
