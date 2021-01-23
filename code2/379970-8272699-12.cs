    <Grid>
        
        <Grid.Resources>
            <Converters:ArrayConverter x:Key="ArrayConverter"/>
        </Grid.Resources>
        
        <ItemsControl
            ItemsSource="{Binding CellArray, Mode=OneWay, Converter={StaticResource ArrayConverter}}">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <ItemsControl
                        ItemsSource="{Binding ., Mode=OneWay}">
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <!-- TODO: Add cell template here -->
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                        <ItemsControl.ItemsPanel>
                            <ItemsPanelTemplate>
                                <StackPanel Orientation="Horizontal" IsItemsHost="True"/>
                            </ItemsPanelTemplate>
                        </ItemsControl.ItemsPanel>
                    </ItemsControl>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Grid>
