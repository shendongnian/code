    <Grid Background="Silver">
        <ItemsControl Grid.IsSharedSizeScope="True" ItemsSource="{Binding Path=Parameters}">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition SharedSizeGroup="Labels" />
                                <ColumnDefinition />
                            </Grid.ColumnDefinitions>
                            <TextBlock Text="{Binding Path=Prompt}" Grid.Column="0" TextAlignment="Right"/>
                            <TextBox Text="{Binding Path=Value}" Width="200" Grid.Column="1"/>
                        </Grid>
                    </StackPanel>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl> 
