    bool HandleCollision(Entity first, Entity second);
}
    public class PlayerShipVsProjectile : ICollisionHandler
    {
        private GameOptions options;
        public PlayersOwnShipHandler(GameOptions options)
        {
            this.options = options;
        }
    
        public bool HandleCollision(Entity first, Entity second)
        {
            if ((!first is Ship) || (!second is Projectile)) return false;
            Ship ship = (Ship)first;
            Projectile projectile = (Projectile)second;
    
            // Because we've decided to put this logic in it's own class, we can easily
            // use a constructor parameter to get access to the game options. Here, we
            // can have access to whether friendly fire is turned on or not.
            if (ship.Owner.IsFriendlyWith(projectile.Shooter) &&
                  !this.options.FriendlyFire) {
                return false;
            }
    
            if (!ship.InvulnerableTypes.Contains(InvulnerableTypes.PROJECTILE))
            {
                 ship.DoDamage(projectile.Damage);
            }
    
            return true;
        }
    }
