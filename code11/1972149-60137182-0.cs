private TaskCompletionSource<Point> _clickSomeWhere;
private async void Button_Click( object sender, RoutedEventArgs e )
{
    ( sender as UIElement ).IsHitTestVisible = false;
    try
    {
        _clickSomeWhere = new TaskCompletionSource<Point>();
        // now we will wait async until we clicked somewhere
        var point = await _clickSomeWhere.Task;
        MessageBox.Show( point.ToString() );
    }
    finally
    {
        ( sender as UIElement ).IsHitTestVisible = true;
    }
}
private void Window_MouseDown( object sender, System.Windows.Input.MouseButtonEventArgs e )
{
    // if we are waiting for some click
    if ( _clickSomeWhere != null )
    {
        // then set the result to the clicked point
        _clickSomeWhere.TrySetResult( e.GetPosition( this ) );
        // remove the TCS because we handled this one
        _clickSomeWhere = null;
    }
}
