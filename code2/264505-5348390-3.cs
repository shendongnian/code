    void form_MouseDown( object sender, MouseEventArgs e )
    {
        if( e.Button == MouseButtons.Left )
        {
            // it is necessary to release mouse capture, so that
            // WPF window will be able to capture mouse input
            ((Control)sender).Capture = false;
            // use helper to acquire window handle
            var helper = new System.Windows.Interop.WindowInteropHelper(
                your_window_reference_goes_here);
            Utility.DragMove(helper.Handle);
        }
    }
