    bool isColliding = false;
    public override void Update(GameTime gameTime) {
        if (!isColliding) {
            // Was not colliding, just started colliding.
            if (star.getBound().Intersects(planet.getBound())) {
                count += 1;
                isColliding = true;
            }
        } else {
            // Was colliding, just stopped colliding.
            if (!star.getBound().Intersects(planet.getBound())) {
                isColliding = false;
            }
        }
    }
