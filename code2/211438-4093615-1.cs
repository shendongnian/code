    private void Canvas_MouseMove( object sender, System.Windows.Input.MouseEventArgs e )
    {
       var pos = e.GetPosition((Canvas)sender);
       Canvas.SetLeft(eye, pos.X);
       Canvas.SetTop(eye, pos.Y);
    }
