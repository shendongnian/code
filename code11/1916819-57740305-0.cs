     <StackLayout>
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="* />
                    <ColumnDefinition Width="* />
                    <ColumnDefinition Width="* />
                </Grid.ColumnDefinitions>
                <Grid.RowDefinitions>
                    <RowDefinition Height="20" />
                </Grid.RowDefinitions>
                <Label Grid.Column="1" Text="First Name" />
                <Label Grid.Column="2" Text="Surname" />
                <Label Grid.Column="3" Text="Date Of Birth" />
            </Grid>
            <ListView x:Name="listView" ItemsSource="{Binding people}">
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <Grid>
                                 <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="* />
                                    <ColumnDefinition Width="* />
                                    <ColumnDefinition Width="* />
                                </Grid.ColumnDefinitions>
                                <Label Grid.Column="1" Text="{Binding FirstName}" />
                                <Label Grid.Column="2" Text="{Binding Surname}" />
                                <Label Grid.Column="3" Text="{Binding Age}" />
                            </Grid>
                        </ViewCell>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
        </StackLayout>
