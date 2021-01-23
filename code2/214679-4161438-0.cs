    public static class DtoFilterExtensions
    {
        public static bool IsIdEqual(this string searchId, string foundId) {
            Debug.Assert(!string.IsNullOrEmpty(foundId));
            return !string.IsNullOrEmpty(searchId) && foundId.Equals(searchId);
        }
    }
