            float farplane = 1000;
            Matrix proj = Matrix.CreateLookAt(Vector3.Zero, Vector3.Forward, Vector3.Up);
            Matrix view = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, this.GraphicsDevice.Viewport.AspectRatio, 1, farplane);
            Vector2 Coord = new Vector2(10,10);     //between 0,0 and 240,360
            Coord.X = Coord.X * (GraphicsDevice.Viewport.Width / 240);
            Coord.Y = Coord.Y * (GraphicsDevice.Viewport.Height / 360);
            Ray r = ProjectRayFromPointOnScreen((int)Coord.X, (int)Coord.Y, proj, view);
            Vector3 ballpos = r.Position + (r.Direction *= (farplane - 1)); //Move just inside the far plane so its not clipped by accident
        public Ray ProjectRayFromPointOnScreen(int x, int y, Matrix ProjectionMatrix, Matrix ViewMatrix)
        {
            Vector3 nearsource = new Vector3(x, y, 0);
            Vector3 farsource = new Vector3(x, y, 1);
            /* The Unproject method: http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.graphics.viewport.unproject.aspx */
            GraphicsDevice graphics = this.GraphicsDevice;
            Vector3 startpoint = graphics.Viewport.Unproject(nearsource,
                                                             ProjectionMatrix,
                                                             ViewMatrix,
                                                             Matrix.Identity);
            Vector3 endpoint = graphics.Viewport.Unproject(farsource,
                                                           ProjectionMatrix,
                                                           ViewMatrix,
                                                           Matrix.Identity);
            Vector3 direction = endpoint - startpoint;
            direction.Normalize();
            Ray r = new Ray(startpoint, direction);
            return r;
        }
