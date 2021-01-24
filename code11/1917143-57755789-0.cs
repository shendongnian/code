    class YourClass
    {    
        Matrix3x3 Rotate(float angle)
        {
            // Create a new matrix
            Matrix3x3 matrix = new Matrix3x3();
    
            // Set the rows of the matrix
    
            matrix.SetRow(0, new Vector3(Mathf.Cos(angle), -Mathf.Sin(angle), 0.0f));
    
            matrix.SetRow(1, new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0.0f));
    
            matrix.SetRow(2, new Vector3(0.0f, 0.0f, 1.0f));
    
            //Return the matrix
            return matrix;    
        }
    
        void Update()
        {    
            // Get the vertz from the matrix
            Vector3[] vertices = mesh.vertices;
    
            // Get the rotation matrix
            Matrix3x3 M = Rotate(angle * Time.deltaTime);
    
            // Rotate each point in the mesh to its new position
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = M.MultiplyPoint(vertices[i]);
            }
    
            // Set the vertices in the mesh to their new position
            mesh.vertices = vertices;
    
            // Recalculate the bounding volume
            mesh.RecalculateBounds();
        }
    }
