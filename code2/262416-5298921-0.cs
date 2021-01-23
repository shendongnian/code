    //center of the rotation
    PointF center = new PointF(...);
    //angle in degrees
    float angle = 45.0f;
    //use a rotation matrix
    using (Matrix rotate = new Matrix())
    {
        //used to restore g.Transform previous state
        GraphicsContainer container = g.BeginContainer();
    
        //create the rotation matrix
        rotate.RotateAt(angle, center);
        //add it to g.Transform
        g.Transform = rotate;
    
        //draw what you want
        ...
    
        //restore g.Transform state
        g.EndContainer(container);
    }
