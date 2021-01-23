    private static void checkCodesInPlayerCenter(GameObject player)
    {
        Vector2 collisionCenter = player.GetCollisionCenter(player.PublicCollisionRectangle);
        var squareAtPixel = TileMap.GetMapSquareAtPixel(collisionCenter);
        if (squareAtPixel  == null)
        {
            return;
        }
        for (int i = 0; i < squareAtPixel.Codes.Count; ++i )
