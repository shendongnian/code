    <ListBox x:Name="usersInGroupLBox">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <CheckBox IsChecked="{Binding IsActive, Mode=TwoWay}" />
                    <TextBlock Text="{Binding User.UserName}" />
                </StackPanel>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
