    public static float ComputeBoundingSphere(Mesh mesh, out Microsoft.DirectX.Vector3 center)
        {
            // Lock the vertex buffer
            Microsoft.DirectX.GraphicsStream data = null;
            try
            {
                data = mesh.LockVertexBuffer(LockFlags.ReadOnly);
                // Now compute the bounding sphere
                return Geometry.ComputeBoundingSphere(data, mesh.NumberVertices, 
                    mesh.VertexFormat, out center);
            }
            finally
            {
                // Make sure to unlock the vertex buffer
                if (data != null)
                    mesh.UnlockVertexBuffer();
            }
        }
        private static Mesh SetSphericalTexture(Mesh mesh)
        {
            Microsoft.DirectX.Vector3 vertexRay;
            Microsoft.DirectX.Vector3 meshCenter;
            double phi;
            float u;
            
            Microsoft.DirectX.Vector3 north = new Microsoft.DirectX.Vector3(0f, 0f, 1f);
            Microsoft.DirectX.Vector3 equator = new Microsoft.DirectX.Vector3(0f, 1f, 0f);
            Microsoft.DirectX.Vector3 northEquatorCross = Microsoft.DirectX.Vector3.Cross(north, equator);
            ComputeBoundingSphere(mesh, out meshCenter);
            using (VertexBuffer vb = mesh.VertexBuffer)
            {
                CustomVertex.PositionNormalTextured[] verts = (CustomVertex.PositionNormalTextured[])vb.Lock(0, typeof(CustomVertex.PositionNormalTextured), LockFlags.None, mesh.NumberVertices);
                try
                {
                    for (int i = 0; i < verts.Length; i++)
                    {
                        //For each vertex take a ray from the centre of the mesh to the vertex and normalize so the dot products work.
                        vertexRay = Microsoft.DirectX.Vector3.Normalize(verts[i].Position - meshCenter);
                        phi = Math.Acos((double)vertexRay.Z);
                        if (vertexRay.Z > -0.9)
                        {
                            verts[i].Tv = 0.121f; //percentage of the image being the top side
                        }
                        else
                            verts[i].Tv = (float)(phi / Math.PI);
                        
                        if (vertexRay.Z == 1.0f || vertexRay.Z == -1.0f)
                        {
                            verts[i].Tu = 0.5f;
                        }
                        else
                        {
                            u = (float)(Math.Acos(Math.Max(Math.Min((double)vertexRay.Y / Math.Sin(phi), 1.0), -1.0)) / (2.0 * Math.PI));
                            //Since the cross product is just giving us (1,0,0) i.e. the xaxis 
                            //and the dot product was giving us a +ve or -ve angle, we can just compare the x value with 0
                            verts[i].Tu = (vertexRay.X > 0f) ? u : 1 - u;
                        }
                    }
                }
                finally
                {
                    vb.Unlock();
                }
            }
            return mesh;
        }
