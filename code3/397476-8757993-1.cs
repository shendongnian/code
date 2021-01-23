    public void ShapeClicked(IShape shape)
    {
        var shape2d = shape as I2DShape;
        if(shape2d != null)
        {
            shape2d.GetArea();
            return;
        }
        var shape3d = shape as I3DShape;
        if(shape3d != null)
        {
            shape3d.GetVolume();
        }
    }
