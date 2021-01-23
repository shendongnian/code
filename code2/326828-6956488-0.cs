    public class OurView : OpenGLControl
    {
        readonly GDITextureFont _myGDITextureFont = new GDITextureFont(new Font("Courier New", 32.0f, FontStyle.Bold));
    
        public override void glDraw()
        {
            OpenGL.glClear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);	// Clear Screen And Depth Buffer
            OpenGL.glLoadIdentity();
            OpenGL.glTranslated(0, 0, -1000); // !!!
            OpenGL.glRotated(35, 1, 1.2, 0.2);
            OpenGL.glScaled(2, 2, 2);
            OpenGL.glPushMatrix();
            OpenGL.glColor3f(1, 1, 0);
            OpenGL.glTranslated(-20, -10, 100);
            _myGDITextureFont.DrawString("Working!");
            OpenGL.glPopMatrix();
            
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Size s = Size;
            double aspect_ratio = (double)s.Width / (double)s.Height;
            OpenGL.glMatrixMode(GL.GL_PROJECTION);
            OpenGL.glLoadIdentity();
            // special frustum, to have nice font display
            OpenGL.glFrustum(-s.Width, s.Width, -s.Height, s.Height, 700, 1300);
            OpenGL.glMatrixMode(OpenGL.GL_MODELVIEW);
            OpenGL.glLoadIdentity();
        }
    }
