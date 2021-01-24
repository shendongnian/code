    <TreeView x:Name="TvSearchResults" Width="200" Margin="20" ItemsSource="{Binding Data.FileLines}">
    <TreeView.ItemTemplate>
        <HierarchicalDataTemplate ItemsSource="{Binding Lines}">
            <TextBlock Text="{Binding Path=Name}"/>
            <HierarchicalDataTemplate.ItemTemplate>
                <DataTemplate>
                    <ItemsControl ItemsSource="{Binding TextParts}">
                        <ItemsControl.ItemsPanel>
                            <ItemsPanelTemplate>
                                <StackPanel Orientation="Horizontal"/>
                            </ItemsPanelTemplate>
                        </ItemsControl.ItemsPanel>
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding Text}">
                                    <TextBlock.Style>
                                        <Style TargetType="TextBlock">
                                            <Style.Triggers>
                                                <DataTrigger Binding="{Binding Path=IsMatch}" Value="True">
                                                    <Setter Property="FontWeight" Value="Bold"/>
                                                </DataTrigger>
                                            </Style.Triggers>
                                        </Style>
                                    </TextBlock.Style>
                                </TextBlock>
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                </DataTemplate>
            </HierarchicalDataTemplate.ItemTemplate>
        </HierarchicalDataTemplate>    
    </TreeView.ItemTemplate>
    </TreeView>
