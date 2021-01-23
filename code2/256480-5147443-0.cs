    enum Face
    {
        Top,
        Bottom,
        Left,
        Right,
        Front,
        Back
    }
    
    enum Direction
    {
        Clockwise,
        CounterClockwise
    }
    
    struct Rotation
    {
         public Face Face;
         public Direction Direction;
    }
    
    LinkedList<Rotation> actions;
