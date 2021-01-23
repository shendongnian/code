    public void Move(int direction)
    {
        double radians = direction * Math.PI / 180;
        //change the x location by the x vector of the speed
        X_Coordinate += (int)(speed * Math.Cos(radians));
        //change the y location by the y vectior of the speed
        Y_Coordinate -= (int)(speed * Math.Sin(radians));
    }
