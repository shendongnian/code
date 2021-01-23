    public abstract class GraphicsControl : Control
    {
        protected GraphicsControl ( System.Windows.Forms.Form Owner )
        {
            owner = Owner;
        }
        protected override void OnCreateControl ( )
        {
                // construction logic
                graphicsDeviceService =
                    GraphicsDeviceService.AddReference
                    (
                        owner.Handle,
                        vpRectangle
                    );
                
                // more construction logic
                // Give derived classes a chance to initialize themselves.
                Initialize ( );
            }
            base.OnCreateControl ( );
        }
    }
