      <ListBox Name="Playlists_ListBox">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid Margin="0,2" >
                        <TextBlock Name="Name" Text="{Binding Title}"  Foreground="White"/>
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
            <ListBox.ContextMenu>
                <ContextMenu StaysOpen="True">
                    <MenuItem Header="Delete"/>
                </ContextMenu>
             </ListBox.ContextMenu>
      </ListBox>
