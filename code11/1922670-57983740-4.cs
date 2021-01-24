    public Vector2 topLeftCorner;
    public Vector2 bottomRightCorner;
    public int layerMask; // Layer mask to check against (optional)
    public float minDepth // Only include objects with a Z coordinate (depth) greater than or equal to this value. (optional)
    public float maxDepth // Only include objects with a Z coordinate (depth) less than or equal to this value. (optional)
    // casts a box using given coordinates and returns all found colliders
    Collider2D[] foundColliders = Physics2D.OverlapAreaAll(topLeftCorner, bottomRightCorner, layerMask, minDepth, maxDepth);
    
    if (foundColliders.Length == 0) {
      // can spawn things
    }
