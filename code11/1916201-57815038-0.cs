xaml
<GridView ScrollViewer.VerticalScrollMode="{x:Bind GridViewScrollMode}"/>
C#:
cs
private void OnPointerPressed(object sender, PointerRoutedEventArgs e)
{
	pointerPoints.Add(e.Pointer.PointerId);
	if (PointerIds.Count == 2)
	{
		((sender as GridView).ContainerFromIndex(0) as GridViewItem).CancelDirectManipulations();
		GridViewScrollMode = ScrollMode.Disabled;
	}
}
