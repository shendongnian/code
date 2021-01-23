            private void CreateMesh()
            {
                meshTerrain = new Mesh(device, (WIDTH - 1) * (HEIGHT - 1) * 2, WIDTH * HEIGHT, MeshFlags.Managed, PositionColored.Format);
                DataStream stream = meshTerrain.VertexBuffer.Lock(0, 0, LockFlags.None);
                stream.WriteRange(vertices);
                meshTerrain.VertexBuffer.Unlock();
                stream.Close();
                stream = meshTerrain.IndexBuffer.Lock(0, 0, LockFlags.None);
                stream.WriteRange(indices);
                meshTerrain.IndexBuffer.Unlock();
                stream.Close();
    
                meshTerrain.GenerateAdjacency(0.5f);
                meshTerrain.OptimizeInPlace(MeshOptimizeFlags.VertexCache);
    
                meshTerrain = meshTerrain.Clone(device, MeshFlags.Dynamic, PositionNormalColored.Format);
                meshTerrain.ComputeNormals();
            }
    
    
            //Drawing
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.DarkSlateBlue, 1.0f, 0);    
            device.BeginScene();
            device.VertexFormat = PositionColored.Format;
            device.SetTransform(TransformState.World, Matrix.Translation(-HEIGHT / 2, -WIDTH / 2, 0) * Matrix.RotationZ(angle));
    
            int numSubSets = meshTerrain.GetAttributeTable().Length;
            for (int i = 0; i < numSubSets; i++)
            {
                meshTerrain.DrawSubset(i);
            }
            device.EndScene();
            device.Present();
