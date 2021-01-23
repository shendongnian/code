    struct Tile
    {
        int Index; // The tiles index in the map [0 - 70 million].
        byte TileTypeId; // An identifier for a tile type.
    }
    class TileType // This is the flyweight object..
    {
        Texture2D Texture; // Gets the texture reference for the tile type...
        // any other information about the tile ie. is it collidable? is it water? etc..
    }
