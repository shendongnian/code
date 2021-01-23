    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      GL.Viewport(this.ClientRectangle);
      GL.MatrixMode(MatrixMode.Projection);
      GL.LoadIdentity();
      GL.Ortho(0, yoursizehere.Width, yoursizehere.Height, 0, -1, 0);
    }
