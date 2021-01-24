xaml
<ScrollViewer Height="500" x:Name="MyScrollViewer">
    <Button Height = "2000">
        <Button.ContextMenu>
            <ContextMenu x:Name="MyContextMenu">
                <MenuItem Header="Item1"></MenuItem>
                <MenuItem Header="Item2"></MenuItem>
                <MenuItem Header="Item3"></MenuItem>
            </ContextMenu>
        </Button.ContextMenu>
    </Button>
</ScrollViewer>
In the codebehind for your view you could do something similar to the following:
csharp
public MainWindow()
{
    InitializeComponent();
    this.MyContextMenu.MouseWheel += OnContextMenuMouseWheel;
}
private void OnContextMenuMouseWheel(object sender, MouseWheelEventArgs e)
{
    var currentOffset = MyScrollViewer.VerticalOffset;
    var newOffset = currentOffset - e.Delta;
    MyScrollViewer.ScrollToVerticalOffset(newOffset);
    e.Handled = true;
}
