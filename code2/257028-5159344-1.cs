    <ItemsControl Grid.IsSharedSizeScope="True" ItemsSource="{Binding AllEffects}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto" SharedSizeGroup="NameColumn" />
                            <ColumnDefinition Width="Auto" SharedSizeGroup="CategoryColumn" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="{Binding Name}" />
                        <TextBlock Text="{Binding Category}" Grid.Column="1" />
                    </Grid>
                    <ItemsControl ItemsSource="{Binding ShaderSupport}">
                        <ItemsControl.ItemsPanel>
                            <ItemsPanelTemplate>
                                <StackPanel Orientation="Horizontal" />
                            </ItemsPanelTemplate>
                        </ItemsControl.ItemsPanel>
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <Grid>
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="60" />
                                    </Grid.ColumnDefinitions>
                                    <CheckBox Grid.Row="1" IsChecked="{Binding Value, Mode=OneWay}" />
                                </Grid>
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                </StackPanel>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
