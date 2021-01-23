        //Offsets any cam location by a zoom scaled window bounds
        Vector2 CamCenterOffset
        {
            get { return new Vector2((game.Window.ClientBounds.Height / Zoom)
                 * 0.5f, (game.Window.ClientBounds.Width / Zoom) * 0.5f);
            }
        }
        //Scales the mouse.X and mouse.Y by the same Zoom as everything.
        Vector2 MouseCursorInWorld
        {
            get
            {
                currMouseState = Mouse.GetState();
                return cameraPosition + new Vector2(currMouseState.X / Zoom,
                    currMouseState.Y / Zoom);
            }
        }
