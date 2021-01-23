    <Border BorderThickness="3" Padding="6">
        <toolkit:GestureService.GestureListener>
            <toolkit:GestureListener Tap="GestureListener_Tap" />
        </toolkit:GestureService.GestureListener>
        <toolkit:ContextMenuService.ContextMenu>
            <toolkit:ContextMenu>
                <toolkit:MenuItem Header="item1" Click="Item1_Click" />
                <toolkit:MenuItem Header="item2" Click="Item2_Click" />
                <toolkit:MenuItem Header="item3" Click="Item3_Click" />
            </toolkit:ContextMenu>
        </toolkit:ContextMenuService.ContextMenu>
        <TextBlock Text="Tap" />
    </Border>
    private void GestureListener_Tap(object sender, GestureEventArgs e)
    {
        Border border = sender as Border;
        ContextMenu contextMenu = ContextMenuService.GetContextMenu(border);
        if (contextMenu.Parent == null)
        {
            contextMenu.IsOpen = true;
        }
    }
