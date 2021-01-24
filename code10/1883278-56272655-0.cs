    <ScrollViewer Name="ScrollViewer_Parent">
        <StackPanel>
            <Frame Name="Frame_Parent" PreviewMouseWheel="Frame_Parent_PreviewMouseWheel" />
                ...
        </StackPanel>
    </ScrollViewer>
    private void Frame_Parent_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
        e.Handled = true;
        var e2 = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
        e2.RoutedEvent = UIElement.MouseWheelEvent;
        ScrollViewer_Parent.RaiseEvent(e2);
    }
