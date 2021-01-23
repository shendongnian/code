        <GridViewColumn >
            <GridViewColumn.CellTemplate>
                <DataTemplate>
                    <ItemsControl ItemsSource="{Binding}">
                        <ItemsControl.ItemsPanel>
                            <ItemsPanelTemplate>
                                <StackPanel Orientation="Horizontal"/>
                            </ItemsPanelTemplate>
                        </ItemsControl.ItemsPanel>
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <StackPanel Orientation="Horizontal">
                                    <TextBlock x:Name="commaTextBlock" Text=", " />
                                    <TextBlock><Hyperlink><Run Text="{Binding Path=Name}" /></Hyperlink></TextBlock>
                                </StackPanel>
                                <DataTemplate.Triggers>
                                    <DataTrigger Binding="{Binding RelativeSource={RelativeSource PreviousData}}" Value="{x:Null}">
                                        <Setter Property="Visibility" TargetName="commaTextBlock" Value="Collapsed"/>
                                    </DataTrigger>
                                </DataTemplate.Triggers>
                            </DataTemplate>
                            
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                </DataTemplate>
            </GridViewColumn.CellTemplate>
        </GridViewColumn>
