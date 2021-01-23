    public class MyClass
    {
        public string s;
        private void CheckLog() { ... }
    }
In any method you might use it remember to check if s.IsNullOrEmpty() to avoid getting a NullPointerException (also I'm assuming that the string should contain something).
