    // get angles between 2 pairs of opposite sides
    float angleBetween1stPair = Tools.GetAngleBetweenLines(corners[0], corners[1], corners[2], corners[3]);
    float angleBetween2ndPair = Tools.GetAngleBetweenLines(corners[1], corners[2], corners[3], corners[0]);
    
    // check 1st pair for parallelism
    if (angleBetween1stPair <= angleError)
    {
        subType = PolygonSubType.Trapezoid;
    
        // check 2nd pair for parallelism
        if (angleBetween2ndPair <= angleError)
        {
            subType = PolygonSubType.Parallelogram;
    
            // check angle between adjacent sides
            if (Math.Abs(Tools.GetAngleBetweenVectors(corners[1], corners[0], corners[2]) - 90) <= angleError)
                subType = PolygonSubType.Rectangle;
    
            //get length of 2 adjacent sides
            float side1Length = (float)corners[0].DistanceTo( corners[1] );
            float side2Length = (float)corners[0].DistanceTo( corners[3] );
    
            if (Math.Abs(side1Length - side2Length) <= maxLengthDiff)
                subType = (subType == PolygonSubType.Parallelogram) ? PolygonSubType.Rhombus : PolygonSubType.Square;
        }
    }
    else
    {
        // check 2nd pair for parallelism - last chence to detect trapezoid
        if (angleBetween2ndPair <= angleError)
        {
            subType = PolygonSubType.Trapezoid;
        }
    }
