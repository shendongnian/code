    <ItemsControl Grid.IsSharedSizeScope="True" ItemsSource="{Binding ShaderSupport}">
        <ItemsControl.ItemsPanel>
            <StackPanel Orientation="Horizontal" />
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto" SharedSizeGroup="HeaderRow" />
                        <RowDefinition Height="Auto" />
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="60" />
                    </Grid.ColumnDefinitions>
                    <TextBlock Text="{Binding Key}" />
                    <CheckBox Grid.Row="1" IsChecked="{Binding Value}" />
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
