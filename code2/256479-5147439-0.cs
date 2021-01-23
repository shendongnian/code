    public sealed class Rotation
    {
        private readonly Action<Cube> _RotateAction;
        private readonly Action<Cube> _UnrotateAction;  // used for undo or backtracking
        private Rotation( Action<Cube> rotateAction, Action<Cube> unrotateAction )
        {
            _RotateAction = rotateAction;
            _UnrotateAction = unrotateAction;
        }
        public void Rotate( Cube cube )   { _RotateAction( cube ); }
        public void Unrotate( Cube cube ) { _Unrotate( cube ); }
        public static readonly RotateFrontFaceClockswise = 
            new Rotation( Cube.RotateFrontFaceClockwise
                          Cube.RotateFrontFaceCounterClockwise );
        public static readonly RotateFrontFaceCounterClockwise = 
            new Rotation( Cube.RotateFrontFaceCounterClockwise,
                          Cube.RotateFrontFaceClockwise );
        public static readonly RotateLeftFaceClockwise = 
            new Rotation( Cube.RotateLeftFaceClockwise,
                          Cube.RotateLeftFaceCounterClockwise );
        public static readonly RotateLeftFaceCounterClockwise = 
            new Rotation( Cube.RotateLeftFaceCounterClockwise,
                          Cube.RotateLeftFaceClockwise );
        // etc..
    }
    // now we can keep track of the state changes of a cube using:
    List<Rotation> cubeRotations = new List<Rotation>();
    cubeRotations.Add( Rotation.RotateFrontFaceCounterClockwise );
    cubeRotations.Add( Rotation.RotateBackFaceClockwise );
    cubeRotations.Add( Rotation.RotateLeftFaceCounterClockwise );
    // to apply the rotations to a cube, you simple walk through the data structure
    // calling the Rotate( ) method on each:
    Cube someCube = new Cube( ... )
    foreach( Rotation r in cubeRotations )
    {
        r.Rotate( someCube );
    }
    // to undo these rotations you can walk the like in reverse:
    foreach( Rotation r in cubeRotations.Reverse() )
    {
        r.Unrotate( someCube );
    }
