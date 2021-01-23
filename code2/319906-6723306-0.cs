    public static IEnumerable<string> GetUsers() {
        lock (...) {
            foreach (var element in onlineUsers)
                yield return element;
            // We need foreach, just "return onlineUsers" would release the lock too early!
        }
    }
