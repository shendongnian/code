     PhysicsLaw[] delegates = new PhysicsLaw[] {
            new PhysicsLaw( PhysicsLaw ),
            new PhysicsLaw( BallLawForAirFriction )
        };
        PhysicsLaw chained = (PhysicsLaw) Delegate.Combine( delegates );
        chained(world);
