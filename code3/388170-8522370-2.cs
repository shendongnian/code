    public void Draw(GraphicsDevice graphicsDevice, Effect theEffect)
		{
			Matrix[] bones = animationManager.GetBones();
			celShader.Parameters["Projection"].SetValue(Camera.Proj);
			celShader.Parameters["View"].SetValue(Camera.View);
			// for each model in the mesh
			foreach (ModelMesh mesh in test.Meshes)
			{
				// for each mesh part
				foreach (ModelMeshPart meshPart in mesh.MeshParts)
				{
					graphicsDevice.SetVertexBuffer(meshPart.VertexBuffer,
							meshPart.VertexOffset);
					graphicsDevice.Indices = meshPart.IndexBuffer;
                    //here i load the texture!!!!!!!!!
					Texture2D texture = ((SkinnedEffect)meshPart.Effect).Texture;
					
					Matrix world = Matrix.Identity;
					celShader.Parameters["Texture"].SetValue(texture);
					celShader.Parameters["World"].SetValue(world);
					
					celShader.Parameters["Bones"].SetValue(bones);
					celShader.Parameters["TintColor"].SetValue(Color.DarkBlue.ToVector4());
					celShader.CurrentTechnique = celShader.Techniques["Toon"];
					// for each effect pass in the cell shader
					foreach (EffectPass pass in celShader.CurrentTechnique.Passes)
					{
						pass.Apply();
						graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0,
							meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount);
					}
				}
			}
    }
