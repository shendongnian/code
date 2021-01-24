	public override void OnRender()
	{
		if (!backgroundColor.HasValue)
			backgroundColor = new Pen(Fill).Color;
		GL.Color4(backgroundColor.Value);
		lock (bitmapSync)
		{
			if (bitmap != null)
				createTexture();
		}
		GL.Enable(EnableCap.Texture2D);
		GL.BindTexture(TextureTarget.Texture2D, texture);
		GL.Begin(PrimitiveType.Quads);
		{
			//TODO rotate image corectly depend on coorners
			GL.TexCoord2(0, 0); GL.Vertex2(LocalPoints[0].X, LocalPoints[0].Y);
			GL.TexCoord2(1, 0); GL.Vertex2(LocalPoints[1].X, LocalPoints[1].Y);
			GL.TexCoord2(1, 1); GL.Vertex2(LocalPoints[2].X, LocalPoints[2].Y);
			GL.TexCoord2(0, 1); GL.Vertex2(LocalPoints[3].X, LocalPoints[3].Y);
		}
		GL.End();
		GL.Disable(EnableCap.Texture2D);
		float wid = Stroke.Width;
		Color col = Stroke.Color;
		if (wid > 0)
		{
			for (int i = 0; i < LocalPoints.Count; i++)
			{
				int j = (i + 1) % LocalPoints.Count;
				GMapControl.line(LocalPoints[i].X, LocalPoints[i].Y, LocalPoints[j].X, LocalPoints[j].Y, wid, col);
			}
		}
	}
	public void createTexture()
	{
		if (bitmap == null)
			return;
		int t = GL.GenTexture();
		GL.BindTexture(TextureTarget.Texture2D, t);
		GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
		GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
		GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
		GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
		GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmap.Width, bitmap.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Rgba, PixelType.UnsignedByte, IntPtr.Zero);
		Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
		System.Drawing.Imaging.BitmapData data = bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
		GL.BindTexture(TextureTarget.Texture2D, t);
		GL.TexSubImage2D(TextureTarget.Texture2D, 0, rect.X, rect.Y, rect.Width, rect.Height, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
		bitmap.UnlockBits(data);
		bitmap.Dispose();
		bitmap = null;
		if (texture > 0)
			GL.DeleteTexture(texture);
		texture = t;
	}
