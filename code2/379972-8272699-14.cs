      <ItemsControl
            ItemsSource="{Binding CellArray, Mode=OneWay}">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Grid
                        Grid.Column="{Binding X}"
                        Grid.Row="{Binding Y}">
                        <!-- TODO: -->
                    </Grid>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <Grid IsItemsHost="True">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition></ColumnDefinition>
                            <ColumnDefinition></ColumnDefinition>
                            <ColumnDefinition></ColumnDefinition>
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition></RowDefinition>
                            <RowDefinition></RowDefinition>
                            <RowDefinition></RowDefinition>
                        </Grid.RowDefinitions>
                    </Grid>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
        </ItemsControl>
