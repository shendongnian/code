     <Grid.RowDefinitions>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            <ContentControl Visibility="Collapsed" Content="{StaticResource ProxyElement}"/>
            <ListBox x:Name="lbTest" Grid.Row="1">
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <Border Background="#F5F5F5" Width="80" Height="60" Margin="0,5,5,5">
                            <Border.ContextMenu>
                                <ContextMenu>
                                    <MenuItem Header="Delete"
                                              Command="{Binding DataContext.DeleteCommand, Source={StaticResource ProxyElement}}">
                                        <MenuItem.Icon>
                                            <Label FontFamily="#FontAwesome" Content="&#xf1f8;" />
                                        </MenuItem.Icon>
                                    </MenuItem>
                                </ContextMenu>
                            </Border.ContextMenu>
                        </Border>
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
