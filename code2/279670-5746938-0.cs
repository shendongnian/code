    protected override void Draw(GameTime gameTime)
    {
        graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
    
        // Copy any parent transforms.
        Matrix[] transforms = new Matrix[myModel.Bones.Count];
        myModel.CopyAbsoluteBoneTransformsTo(transforms);
    
        // Draw the model. A model can have multiple meshes, so loop.
        foreach (ModelMesh mesh in myModel.Meshes)
        {
            // This is where the mesh orientation is set, as well 
            // as our camera and projection.
            foreach (BasicEffect effect in mesh.Effects)
            {
                effect.EnableDefaultLighting();
                effect.World = transforms[mesh.ParentBone.Index] * 
                    Matrix.CreateRotationY(modelRotation)
                    * Matrix.CreateTranslation(modelPosition);
                effect.View = Matrix.CreateLookAt(cameraPosition, 
                    Vector3.Zero, Vector3.Up);
                effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                    MathHelper.ToRadians(45.0f), aspectRatio, 
                    1.0f, 10000.0f);
            }
            // Draw the mesh, using the effects set above.
            mesh.Draw();
        }
        base.Draw(gameTime);
    }
