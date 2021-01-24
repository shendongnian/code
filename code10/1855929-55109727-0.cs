private void Manipulator_OnManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
{
    if (e.Position.X > ContainerGrid.Width - RotateRectangle.Width && 
    e.Position.Y < ContainerGrid.Height - RotateRectangle.Height)
    {
    _isRotating = true;
    var startingRadians = Math.Atan2((currentLocation.Y - objectCenter.Y),     (currentLocation.X - objectCenter.X));
    startingAngle = startingRadians * 180 / Math.PI;
    return;
    }
    _isRotating = false;
}
private void Manipulator_OnManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
{ 
    if (_isRotating)
    {
    Point currentLocation = e.Position;
    double radians = Math.Atan2((currentLocation.Y - objectCenter.Y),     (currentLocation.X - objectCenter.X));
    var angle = radians * 180 / Math.PI;
    RotateGrid.Angle = angle-startingAngle;
    }
}
