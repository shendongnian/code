    public void Register(Sprite sprite)
    {
        // If the sprite object exists
        if (NullHelper.Exists(sprite))
        {
            // if this is the RedCar
            if (sprite.Name == "RedCar")
            {
                // Set the RedCar
                RedCar = sprite;
            }
            else 
            {
                // Set the WhiteCar
                WhiteCar = sprite;
            }
        }
    }
