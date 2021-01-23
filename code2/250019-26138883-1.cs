        [DllImport( "user32.dll", SetLastError = true )]
        public static extern IntPtr WindowFromPoint( [In] POINTAPI Point );
        private void _mouseListener_MouseClick( object sender, MouseEventArgs e )
        {
            var localPoint = this.PointToClient( e.Location );
            bool containsPoint = this.ClientRectangle.Contains( localPoint );
            var windowHandle = WindowFromPoint( e.Location );
            var ctl = (Form)Form.FromHandle( windowHandle );
            bool mainFormClicked = ctl != null && ctl.Handle == this.Handle;
            if( containsPoint && mainFormClicked  )
            {
                  //form click is intercepted!
            }
        }
