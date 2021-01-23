    <ListBox x:Name="lstPlayers" >
        <ListBox.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text="{Binding FirstName}"></TextBlock>
                    <TextBlock Text="{Binding LastName}"></TextBlock>
                </StackPanel>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
