        <ListView x:Name="listView" ItemsSource="taxes">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <ViewCell>
                        <Grid>
                            <Grid.ColumnDefinitions>
                               <ColumnDefinition Width="2*" />
                               <ColumnDefinition Width="2*" />
                            </Grid.ColumnDefinitions>
                            <label text = "{binding amount}" grid.Column="0"/>
                            <label text = "{binding date }" grid.Column="1"/>
                        </Grid>
                    </ViewCell>
                </DataTemplate>
            </ListView.ItemTemplate>
         </ListView>
