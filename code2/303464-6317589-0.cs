        public static class HttpContextHelper {
        private static object lockObj = new object();
        private static HttpContextBase mockHttpContext;
        /// <summary>
        /// Access the HttpContext using the Abstractions.
        /// </summary>
        public static HttpContextBase Current {
            get {
                lock (lockObj) {
                    if (mockHttpContext == null && HttpContext.Current != null) {
                        return new HttpContextWrapper(HttpContext.Current);
                    }
                }
                return mockHttpContext;
            }
            set {
                lock (lockObj) {
                    mockHttpContext = value;
                }
            }
        }
    }
