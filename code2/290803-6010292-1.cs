    public class DebugLogger : Logger {
        protected override void Write(string message) {
            Debug.Print(message);
        }
    }
