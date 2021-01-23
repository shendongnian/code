        <ListBox ItemsSource="{Binding Data}">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <StackPanel Grid.IsSharedSizeScope="True">
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition SharedSizeGroup="A"/>
                                <ColumnDefinition SharedSizeGroup="B"/>
                                <ColumnDefinition SharedSizeGroup="C"/>
                                <ColumnDefinition SharedSizeGroup="D"/>
                            </Grid.ColumnDefinitions>
                            <Grid.Children>
                                <TextBlock Grid.Column="0" Grid.ColumnSpan="2" Name="Header" Text="{Binding Header}" FontSize="20" Foreground="Blue"/>
                                <TextBlock Grid.Column="2" Text="lorem"/>
                                <TextBlock Grid.Column="3" Text="ipsum"/>
                            </Grid.Children>
                        </Grid>
                        <ListBox ItemsSource="{Binding Departures}">
                            <ListBox.ItemTemplate>
                                <DataTemplate>
                                    <Grid>
                                        <Grid.ColumnDefinitions>
                                            <ColumnDefinition SharedSizeGroup="A"/>
                                            <ColumnDefinition SharedSizeGroup="B"/>
                                            <ColumnDefinition SharedSizeGroup="C"/>
                                            <ColumnDefinition SharedSizeGroup="D"/>
                                        </Grid.ColumnDefinitions>
                                        <Grid.Children>
                                            <TextBlock Grid.Column="0" Text="{Binding Line}" Background="DarkBlue" Foreground="White"/>
                                            <TextBlock Grid.Column="1" Text="{Binding Name}" Foreground="DarkBlue"/>
                                            <TextBlock Grid.Column="2" Text="{Binding Lorem}" Foreground="DarkBlue"/>
                                            <TextBlock Grid.Column="3" Text="{Binding Ipsum}" Foreground="DarkBlue"/>
                                        </Grid.Children>
                                    </Grid>
                                </DataTemplate>
                            </ListBox.ItemTemplate>
                        </ListBox>
                    </StackPanel>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
