    private object locker = new object();
    
    private void glControl1_Paint(object sender, PaintEventArgs e)
    {
        lock(locker) {
           if (glControl2.Created &&
                     glControl2.Context.IsCurrent)
           { glControl2.Context.MakeCurrent(null); }
           if (glControl1.Context.IsCurrent == false)
           { glControl1.MakeCurrent(); }
           Render();
        }         
    }
    private void glControl2_Paint(object sender, PaintEventArgs e)
    {
        lock(locker) {
           if (glControl1.Created &&
              glControl1.Context.IsCurrent)
           { glControl1.Context.MakeCurrent(null); }
           if (glControl2.Context.IsCurrent == false)
           { glControl2.MakeCurrent(); }
           GL.Flush();
           glControl2.SwapBuffers();
           Render2();
        }
    }
