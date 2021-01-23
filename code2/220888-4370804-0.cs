    GL.GetFloat(GetPName.ModelviewMatrix, out model);
    GL.GetFloat(GetPName.ProjectionMatrix, out proj);
    GL.GetFloat(GetPName.Viewport, view);
    
    Matrix4.Transpose(ref model, out model);
    Matrix4.Transpose(ref proj, out proj);
    
    Vector4 posa = new Vector4(0.0f, s.Position.Y, 1.0f, s.Position.X);
    Vector4 posb = new Vector4(s.Position.Y, 1.0f, s.Position.X, 0.0f);
    Vector4 posc = new Vector4(1.0f, s.Position.X, 0.0f, s.Position.Y);
    
    Vector4 one = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
    Matrix4 posv = new Matrix4(pos, posa, posb, posc);
    
    Matrix4 ProjPos = Matrix4.Mult(Matrix4.Mult(proj, model), posv);
    Matrix4.Transpose(ref ProjPos, out ProjPos);
    
    Vector2f posout = new Vector2f(
       (0 + (this.glc.Width * (ProjPos.Column0.X / ProjPos.Column0.W + 1.0f)) - (this.glc.Width / 2.0f)),
       (0 + (this.glc.Height * (ProjPos.Column0.Y / ProjPos.Column0.W + 1.0f)) - (this.glc.Height / 2.0f))
    );
