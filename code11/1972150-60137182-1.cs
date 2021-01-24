private TaskCompletionSource<Point> _clickSomeWhere;
private async void Button_Click( object sender, RoutedEventArgs e )
{
    ( sender as UIElement ).IsHitTestVisible = false;
    try
    {
        var point = await ReadPointAsync();
        MessageBox.Show( point.ToString() );
    }
    finally
    {
        ( sender as UIElement ).IsHitTestVisible = true;
    }
}
private async Task<Point> ReadPointAsync()
{
    _clickSomeWhere = new TaskCompletionSource<Point>();
    // here is your prompt
    this.Title = "Please click on the point you like!";
    try
    {
        return await _clickSomeWhere.Task;
    }
    finally
    {
        this.Title = "Thank you!";
    }
}
private void Window_MouseDown( object sender, System.Windows.Input.MouseButtonEventArgs e )
{
    if ( _clickSomeWhere != null )
    {
        _clickSomeWhere.TrySetResult( e.GetPosition( this ) );
        _clickSomeWhere = null;
    }
}
