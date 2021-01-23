    class UserEqualityComparer : IEqualityComparer<User> {
        public bool Equals(User x, User y) {
            if (Object.ReferenceEquals(x, y)) {
                return true;
            }
            if (x == null || y == null) {
                return false;
            }
            return x.FirstName == y.FirstName && x.LastName == y.LastName;
        }
        public int GetHashCode(User obj) {
            if (obj == null) {
                return 0;
            }
            return 23 * obj.FirstName.GetHashCode() + obj.LastName.GetHashCode();
        }
    }
