    public class Person {
        public string FullName { get; private set; }
        public string FamilyName { get; private set; }
        public string KnownAs { get; private set; }
        public void SetNames( string full, string family, string known) {
            lock (padLock) {
                ...
            }
        }
    }
