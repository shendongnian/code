        Vector2 GetScreenCoordinates(Vector3 ObjectCoordinate)
        {
            // ref: http://www.songho.ca/opengl/gl_transform.html
            Vector4 obj = new Vector4(ObjectCoordinate.X, ObjectCoordinate.Y, ObjectCoordinate.Z, 1.0f);
            Matrix4 projection = new Matrix4();
            Matrix4 modelView = new Matrix4();
            Vector4 viewPort = new Vector4();
            GL.GetFloat(GetPName.ModelviewMatrix, out modelView);
            GL.GetFloat(GetPName.ProjectionMatrix, out projection);
            GL.GetFloat(GetPName.Viewport, out viewPort);
            Vector4
                eye = Vector4.Transform(obj, modelView),
                clip = Vector4.Transform(eye, projection);
            Vector3
                ndc = new Vector3(clip.X / clip.W, clip.Y / clip.W, clip.Z / clip.W);
            Vector2
                w = new Vector2(viewPort.Z / 2 * ndc.X + viewPort.X + viewPort.Z / 2,
                                viewPort.W / 2 * ndc.Y + viewPort.Y + viewPort.W / 2);
            return w;
        }
