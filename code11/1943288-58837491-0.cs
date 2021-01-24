cs
MainWindow window = this;
double oldHeight = window.Height; // saving regular Height for rollback
window.Height = 5000; // large enough temporary increase
window.SynchronouslyRedraw();
PrintToPdf(); // the method you already have
window.Height = oldHeight; // undo temporary increase
I like to use this extension method for synchronous redrawing operations:
cs
public static class UIElementExtensions {
	/// <summary>
	/// Synchronously redraws this <see cref="UIElement"/>. Only works if in a <see cref="Window"/> visual tree.
	/// </summary>
	public static void SynchronouslyRedraw(this UIElement uiElement) {
		uiElement.InvalidateVisual();
		Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() => { })).Wait();
		Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() => { })).Wait();
	}
}
