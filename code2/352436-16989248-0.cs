     <ListBox.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Vertical" 
                            ContextMenuService.ShowOnDisabled="True">
                    <StackPanel.ContextMenu>
                        <ContextMenu>
                            <MenuItem Header="Delete" Click="DeleteEvent">      
                            </MenuItem>
                        </ContextMenu>
                    </StackPanel.ContextMenu>
                        <TextBlock Text="{Binding EventName}">
                    </TextBlock>        
                </StackPanel>
            </DataTemplate>
        </ListBox.ItemTemplate>
