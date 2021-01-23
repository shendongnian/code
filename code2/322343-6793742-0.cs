    physicsWorld = new World(GRAVITY);
    physicsDebug = new DebugViewXNA(physicsWorld);
    physicsDebug.LoadContent(this.GraphicsDevice, this.Content);
    physicsDebug.AppendFlags(DebugViewFlags.Shape);
    physicsDebug.AppendFlags(DebugViewFlags.PolygonPoints);
