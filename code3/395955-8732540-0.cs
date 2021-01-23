    public void DrawModel( Model myModel, float modelRotation, Vector3 modelPosition,
                           Vector3 cameraPosition
         ) {
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
                                Matrix.CreateRotationY(modelRotation) *
                                Matrix.CreateTranslation(modelPosition);
                effect.View = Matrix.CreateLookAt(cameraPosition,
                                Vector3.Zero, Vector3.Up);
                effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                                        MathHelper.ToRadians(45.0f), 1.333f, 
                                        1.0f, 10000.0f);
                effect.LightingEnabled = true; // turn on the lighting subsystem.
                effect.DirectionalLight0.DiffuseColor = new Vector3(0.5f, 0, 0); // a red light
                effect.DirectionalLight0.Direction = new Vector3(1, 0, 0);  // coming along the x-axis
                effect.DirectionalLight0.SpecularColor = new Vector3(0, 1, 0); // with green highlights
            }
            // Draw the mesh, using the effects set above.
            mesh.Draw();
        }
    }
