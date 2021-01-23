    abstract class Unit {
      public abstract Unit Add(Unit unit);
      public virtual Measure Add(Measure unit) { return unit; }
      public virtual Weight Add(Weight unit) { return unit; }
    }
    class Measure : Unit {
      public override Measure Add(Measure unit) { 
        // ...
      }
      public override Unit Add(Unit unit) {
        return unit.Add(this);
      }
    }
    class Weight : Unit {
      public override Weight Add(Weight unit) {
        // ...
      }
      public override Unit Add(Unit unit) {
        return unit.Add(this);
      }
    }
