    List<Ball> balls = new List<Ball>();
    
    // Initialize the balls into a grid structure:
    for( int i=0; i < numberOfRows; i++ )
        for( int j=0; j < numberOfColumns; j++ )
            balls.Add( new Ball( i * gridWidth, j * gridHeight, Color.Blue );
        
    // ... some other code probably goes here ...
    
    var trash = balls.Where( ball => ball.Intersects( marquee ) );
    foreach( Rectangle ball in trash )
        balls.Remove( ball );
