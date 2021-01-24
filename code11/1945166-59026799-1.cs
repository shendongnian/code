	public override void OnRender()
	{
		if (LocalPoints.Count == 4 && !targetPosition.IsEmpty)
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
			// center point
			GPoint localTargetPosition = MainForm.instance.gMapControl.FromLatLngToLocalWithOffset(targetPosition);
			// determines distances to center for all vertexes
			double dUL = Common.distance(new double[] { LocalPoints[0].X, LocalPoints[0].Y }, new double[] { localTargetPosition.X, localTargetPosition.Y });
			double dUR = Common.distance(new double[] { LocalPoints[1].X, LocalPoints[1].Y }, new double[] { localTargetPosition.X, localTargetPosition.Y });
			double dLR = Common.distance(new double[] { LocalPoints[2].X, LocalPoints[2].Y }, new double[] { localTargetPosition.X, localTargetPosition.Y });
			double dLL = Common.distance(new double[] { LocalPoints[3].X, LocalPoints[3].Y }, new double[] { localTargetPosition.X, localTargetPosition.Y });
			var texCoords = new[]
			{
				new Vector4(0, 0, 1, 1),
				new Vector4(1, 0, 1, 1),
				new Vector4(1, 1, 1, 1),
				new Vector4(0, 1, 1, 1)
			};
			texCoords[0] *= (float)((dUL + dLR) / dLR);
			texCoords[1] *= (float)((dUR + dLL) / dLL);
			texCoords[2] *= (float)((dLR + dUL) / dUL);
			texCoords[3] *= (float)((dLL + dUR) / dUR);
			GL.Begin(PrimitiveType.Quads);
			{
				//GL.TexCoord2(0, 0); //UL  LocalPoints[0] gimbalUL
				//GL.TexCoord2(1, 0); //UR  LocalPoints[1] gimbalUR
				//GL.TexCoord2(1, 1); //LR  LocalPoints[2] gimbalLR
				//GL.TexCoord2(0, 1); //LL  LocalPoints[3] gimbalLL
				GL.TexCoord4(texCoords[0]); GL.Vertex4(LocalPoints[0].X, LocalPoints[0].Y, 1, 1);
				GL.TexCoord4(texCoords[1]); GL.Vertex4(LocalPoints[1].X, LocalPoints[1].Y, 1, 1);
				GL.TexCoord4(texCoords[2]); GL.Vertex4(LocalPoints[2].X, LocalPoints[2].Y, 1, 1);
				GL.TexCoord4(texCoords[3]); GL.Vertex4(LocalPoints[3].X, LocalPoints[3].Y, 1, 1);
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
		else
		{
			base.OnRender();
		}
	}
