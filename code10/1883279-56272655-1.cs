    <ScrollViewer Name="ScrollViewer_Parent">
        <StackPanel>
            <Frame Name="Frame_Parent" PreviewMouseWheel="BubblePreviewMouseWheel" />
                ...
        </StackPanel>
    </ScrollViewer>
    private void BubblePreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
        e.Handled = true;
        var e2 = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
        e2.RoutedEvent = UIElement.MouseWheelEvent;
        ((UIElement)sender).RaiseEvent(e2);
    }
