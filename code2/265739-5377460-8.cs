    public interface ILegacy {
        public bool Remove(int user);
    }
    
    public static class LegacyExtensions {
        public static bool Remove(this ILegacy @this, Id<Person> user) {
            return @this.Remove((int)user);
        }
    }
