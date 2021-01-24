    * In C# they look like this:
            public class Control : Component
            {
                public event EventHandler Click;
                protected virtual void OnClick(EventArgs e)
                {
                    this.Click?.Invoke( this, e ); 
                }
                private void OnWin32WindowMessage( Message m )
                {
                    switch( m.EventId )
                    {
                        case Win32.MouseClick:
                            this.OnClick( EventArgs.Empty );
                            break;
                        case Win32.MouseMove:
                            this.OnMouseMove( EventArgs.Empty );
                            break;
                        case Win32.KeyDown:
                            this.OnKeyDown( EventArgs.Empty );
                            break;
                        // etc
                    }
                }
            }
