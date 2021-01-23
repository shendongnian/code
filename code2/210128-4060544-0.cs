                private void canevas_MouseDown( object sender , MouseEventArgs e )
                {
                        _topLeft = new Point( e.X , e.Y );
                        if( e.Button == MouseButtons.Left )
                        {
                                _topLeft = new Point( e.X , e.Y );
                                _drawing = true;
                        }
                }
                private void canevas_MouseUp( object sender , MouseEventArgs e )
                {
                        _drawing = false;
                        _bottomRight = new Point( e.X , e.Y );
                        int newX = _topLeft.X - (_bottomRight.X - _topLeft.X) / 2;
                        int newY =_topLeft.Y + (_bottomRight.Y - _topLeft.Y) / 2;
                        MouseEventArgs me = new MouseEventArgs( MouseButtons.Left , 1 , newX , newY , 0 );
                       
                        canevas_MouseClick( canevas , me );
                }
                private void canevas_MouseMove( object sender , MouseEventArgs e )
                {
                        if( _drawing )
                        {
                                _bottomRight = new Point( e.X , e.Y );
                                canevas.Invalidate();
                        }
                }
