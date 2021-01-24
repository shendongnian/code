    List<Missile> missiles = new List<Missile> {
        new Missile(...),
        new TrackingMissile(...)
    };
    foreach (var missile in missiles) {
      if (missile is TrackingMissile tm) {
        tm.Update(target);
      } else { 
        missile.Update();
      }
    }
