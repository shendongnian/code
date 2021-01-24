    public static class ILoggableUtils { // For extension methods on ILoggable
        public static void Log(this ILoggable instance, string message) {
             DoSomethingWith(message, instance.SomePropertyOfILoggable);
        }
    }
