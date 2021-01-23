    // NOT RECOMMENDED!!!
    public static class MockedSessionExtensions {
        public static IQueryable<T> Query<T>(this ISession session) {
            // your mocked impl goes here
        }
    }
