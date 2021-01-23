private void Render()
{
   // Every frame
   GL.Begin(BeginMode.Points);
   GL.MatrixMode(MatrixMode.Modelview);
   GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
   GL.LoadMatrix(ref cameraMatrix);
   GL.Begin(BeginMode.Points);
   // Here I can add lots of points. I add 200k without any big problem.
   // It seems these points could have been passed in as an array pointer too,
   //  but I'll look at that later.
   GL.Vertex3(x2, y2, z2);
   GL.End();
   glControl.SwapBuffers();
}
