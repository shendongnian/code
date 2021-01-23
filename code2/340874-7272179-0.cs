    /// <summary>
    /// Transforms a bounding box for collision detection
    /// </summary>
    /// <param name="vehicleBounds">Original, object-centered bounding box that contains a car model</param>
    /// <param name="vehicleWorldMatrix">Vehicle's world transformation matrix (does not include projection or view)</param>
    /// <returns>An axis-aligned bounding box (AABB) that will com </returns>
    protected BoundingBox TransformBoundingBox(BoundingBox vehicleBounds, Matrix vehicleWorldMatrix)
    {
        var vertices = vehicleBounds.GetCorners();
    
        /// get a couple of vertices to hold the outer bounds of the transformed bounding box.
        var minVertex = new Vector3(float.MaxValue);
        var maxVertex = new Vector3(float.MinValue);
    
        for(int i=0;i<vertices.Length;i++)
        {
            var transformedVertex = Vector3.Transform(vertices[i],vehicleWorldMatrix);
    
            /// update min and max with the component-wise minimum of each transformed vertex
            /// to find the outer limits fo teh transformed bounding box
            minVertex = Vector3.Min(minVertex, transformedVertex);
            maxVertex = Vector3.Max(maxVertex, transformedVertex);
        }
    
        var result = new BoundingBox(minVertex, maxVertex);
    
        return result;
    }
