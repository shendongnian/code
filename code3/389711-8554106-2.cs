    Vector3 velocity; //lets say your unit is m/s
    Vector3 position; //lets say you measure units in meters
    protected override void Update(GameTime gameTime){
        position += velocity * (gameTime.ElapsedGameTime.TotalMiliseconds / 1000.0f);
    }
