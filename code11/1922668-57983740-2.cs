    public Vector2 topLeftCorner;
    public Vector2 bottomRightCorner;
    
    // casts a box using given coordinates and returns all found colliders
    Collider2D foundColliders = Physics2D.OverlapAreaAll(topLeftCorner, bottomRightCorner, LayerMask, minZDepth, maxZDepth);
    
    if (foundColliders.Length == 0) {
      // can spawn things
    }
