      <ListView  x:Name="listView" ItemsSource="{Binding MyModels} ">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <ViewCell>
                        <Grid >
                            <Grid.RowDefinitions>
                                <RowDefinition Height="*" />
                                
                            </Grid.RowDefinitions>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="*" />
                                <ColumnDefinition Width="*" />
                            </Grid.ColumnDefinitions>
                            <Label Grid.Row="0" Grid.Column="0" Text="{Binding State}"
                                />
                            <Label Grid.Row="0" Grid.Column="1" Text="{Binding Votes}"
                              
                               />
                        </Grid>
                       
                            
                    </ViewCell>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
