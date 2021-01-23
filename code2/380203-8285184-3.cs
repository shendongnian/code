    Matrix[] bones = player.GetSkinTransforms();
    // Compute camera matrices.
    Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, -30), // Change the last number according to the size of your model
                                              new Vector3(0, 0, 0), Vector3.Up);
    Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                            device.Viewport.AspectRatio,
                                                            1,
                                                            10000);
    // Render the skinned mesh.
    foreach (ModelMesh mesh in model.Meshes)
    {
        foreach (SkinnedEffect effect in mesh.Effects)
        {
            effect.SetBoneTransforms(bones);
            effect.View = view;
            effect.Projection = projection;
            effect.EnableDefaultLighting();
            effect.SpecularColor = new Vector3(0.25f);
            effect.SpecularPower = 16;
        }
        mesh.Draw();
    }
    
