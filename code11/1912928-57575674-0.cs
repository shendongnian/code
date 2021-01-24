C#
private void AssociatedObject_Click(object sender, System.Windows.RoutedEventArgs e)
{
	var tooltip = this.AssociatedObject.ToolTip as ToolTip;
	tooltip = new ToolTip();
	tooltip.Content = "Log was copied to your Clipboard";
	tooltip.IsOpen = true;  
	
	HideToolTip();	
}
private async void HideToolTip(ToolTip toolTip)
{
	await Task.Delay(3 * 1000); // 3 second
	toolTip.IsOpen = false;
}
