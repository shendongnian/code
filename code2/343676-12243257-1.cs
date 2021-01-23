    internal class SessionHelper {
        private void Set<T>(string key, T value) {
            HttpContext.Current.Session[key] = value;
        }
        private T Get<T>(string key) {
            return (T)HttpContext.Current.Session[key];
        }
        public int MemberID {
            get { return Get<int>("SK_MemberID"); }
            set { Set<int>("SK_MemberID", value); }
        }
        public string MemberAccount {
            get { return Get<string>("SK_MemberAccount"); }
            set { Set<string>("SK_MemberAccount", value); }
        }
        public string MemberDisplayName {
            get { return Get<string>("SK_MemberDisplayName"); }
            set { Set<string>("SK_MemberDisplayName", value); }
        }
        public string MemberGuid {
            get { return Get<string>("SK_MemberGuid"); }
            set { Set<string>("SK_MemberGuid", value); }
        }
    }
