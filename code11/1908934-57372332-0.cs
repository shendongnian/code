        <Grid x:Name="mainGrid" MouseMove="MovShp_MouseMove"  MouseUp="MovShp_MouseUp" Background="Transparent" >
		<Canvas x:Name="CanvasImplant" HorizontalAlignment="Stretch" VerticalAlignment="Stretch">
			<Rectangle Canvas.Left="10" Canvas.Top="20" x:Name="MovableShape" Fill="Transparent"  Opacity="0.85" Width="93" Height="62" Stroke="Black" 
			           StrokeThickness="1" MouseDown="MovShp_MouseDown" />
		</Canvas>
	</Grid>
   
    private void MovShp_MouseDown(object sender, MouseButtonEventArgs e)
    {
        _drag = true;
        Cursor = Cursors.Hand;
        _startPt = e.GetPosition(CanvasImplant);
        Mouse.Capture(CanvasImplant);
    }
    
    private void MovShp_MouseUp(object sender, MouseButtonEventArgs e)
    {
        _drag = false;
        Cursor = Cursors.Arrow;
        Mouse.Capture(null);
    }
    
    private void MovShp_MouseMove(object sender, MouseEventArgs e)
    {
        if (_drag)
        {
            double deltaX = e.GetPosition(CanvasImplant).X - _startPt.X;
            double deltaY = e.GetPosition(CanvasImplant).Y - _startPt.Y;
    
            var newX = deltaX + MovableShape.GetLeft();
            var newY = deltaY + MovableShape.GetTop();
    
            if (newX < 0)
                newX = 0;
            else if (newX + MovableShape.ActualWidth > CanvasImplant.ActualWidth)
                newX = CanvasImplant.ActualWidth - MovableShape.ActualWidth;
    
            if (newY < 0)
                newY = 0;
            else if (newY + MovableShape.ActualHeight > CanvasImplant.ActualHeight)
                newY = CanvasImplant.ActualHeight - MovableShape.ActualHeight;
    
            MovableShape.SetLeft( newX);
            MovableShape.SetTop( newY);
    
            _startPt = new Point(newX, newY);
        }    }
