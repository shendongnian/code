        public State Euler(Vector2 acceleration, double step)
        {
            Vector2 newVelocity = this.Velocity + acceleration * step;
            Vector2 newPosition = this.Position + this.Velocity * step;
            return new State(newPosition, newVelocity);
        }
    }
     
