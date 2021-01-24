     protected override void OnActivated(IActivatedEventArgs args)
            {
                // When the app was activated by a Protocol (custom URI scheme), forwards
                // the URI to the MainPage through a Navigate event.
                if (args.Kind == ActivationKind.Protocol)
                {
                    // Extracts the authorization response URI from the arguments.
                    ProtocolActivatedEventArgs protocolArgs = (ProtocolActivatedEventArgs)args;
                    Uri uri = protocolArgs.Uri;
                    Debug.WriteLine("Authorization Response: " + uri.AbsoluteUri);
    
                    // Gets the current frame, making one if needed.
                    var frame = Window.Current.Content as Frame;
                    if (frame == null)
                        frame = new Frame();
    
                    // Opens the URI for "navigation" (handling) on the MainPage.
                    frame.Navigate(typeof(MainPage), uri);
                    Window.Current.Content = frame;
                    Window.Current.Activate();
                }
            }
