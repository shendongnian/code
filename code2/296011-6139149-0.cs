    // A view frustum almost always is initialized with the ViewMatrix * ProjectionMatrix
    BoundingFrustum viewFrustum = new BoundingFrustum(ActivePlayer.ViewMatrix * ProjectionMatrix);
    
    // Check every entity in the game to see if it collides with the frustum.
    foreach (Entity sourceEntity in entityList)
    {
        // Create a collision sphere at the entities location. Collision spheres have a
        // relative location to their entity and this translates them to a world location.
        BoundingSphere sourceSphere = new BoundingSphere(sourceEntity.Position,
                                      sourceEntity.Model.Meshes[0].BoundingSphere.Radius);
    
        // Checks if entity is in viewing range, if not it is not drawn
        if (viewFrustum.Intersects(sourceSphere))
            sourceEntity.Draw(gameTime);
    }
