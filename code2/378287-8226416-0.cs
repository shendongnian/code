    <Grid>
        <ListBox Name="songList" MouseDoubleClick="songList_MouseDoubleClick">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Path=songName}"/>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </Grid>
