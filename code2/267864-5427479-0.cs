        <GridViewColumn >
            <GridViewColumn.CellTemplate>
                <DataTemplate>
                    <ItemsControl>
                        <ItemsControl.ItemsPanel>
                            <ItemsPanelTemplate>
                                <StackPanel Orientation="Horizontal" />
                            </ItemsPanelTemplate>
                        </ItemsControl.ItemsPanel>
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <TextBlock>
                                    <Hyperlink><Run Text="{Binding Path=Name}" /></Hyperlink>
                                </TextBlock>
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                </DataTemplate>
            </GridViewColumn.CellTemplate>
        </GridViewColumn>
