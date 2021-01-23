    // Pseudocode
    onMouseMove()
    {
        // Using calculation for R vector above
        Vector r = calulateVector();
        // Assuming passed in the number of points to translate 
        // (or some derivative of mousemove)
        let int pts = mousePointsMovedLeftOrRight;
        // Perform a translate in direction of R
        Vector targetPosition = TargetObject.PositionVector;
        targetPosition.X += r.X * pts;
        targetPosition.Y += r.Y * pts;
        targetPosition.Z += r.Z * pts;
    }
