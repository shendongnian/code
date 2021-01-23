    public sealed class EntityEqualityComparer : IEqualityComparer<Entity.Limit> {
      public bool Equals(Entity.Limit left, Entity.Limit right) {
        return 
          left.Value1 == right.Value1 &&
          left.Value2 == right.Value2;
      }
      public int GetHashCode(Entity.Limit left) {
        return left.Value1 ^ left.Value2;
      }
    }
