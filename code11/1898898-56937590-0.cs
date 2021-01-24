csharp
private void DisableAllControls()
{
    // parallel execution cause of many elements
    Parallel.For(0, VisualTreeHelper.GetChildrenCount(this), index =>
    {
        (VisualTreeHelper.GetChild(this, index)
        as UIElement).IsEnabled = false;
    });
}
I also added a `MouseDownEvent` to get focus an the new window if the user clicks on the "freezed" main window. (There will be only one additional window open at the same time).
csharp
private void FocusLastOpen_MouseDown(object sender, MouseEventArgs e)
{
    if (App.Current.Windows.Count > 1)
    {
        foreach (Window w in App.Current.Windows)
        {
            if (w.IsEnabled && w.GetType() != typeof(MainWindow))
            {
                w.Focus();
            }
        }
    }
}
To reactivate the elements of the main window when the other window has closed I've written a static method which will be executed on the `ClosingEvent`.
csharp
public static void EnableAllControls()
{
    MainWindow obj = null;
    foreach(Window w in App.Current.Windows)
    {
        if(w.GetType() == typeof(MainWindow))
        {
            obj = w as MainWindow;
            break;
        }
    }
    if(obj == null) return;
    Parallel.For(0, VisualTreeHelper.GetChildrenCount(obj), index =>
    {
        (VisualTreeHelper.GetChild(obj, index)
        as UIElement).IsEnabled = true;
    });
}
