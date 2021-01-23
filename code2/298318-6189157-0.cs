    static class ControlDefaults<T> where T : Control {
        public static Action<T> Action { get; internal set; }
    }
    static void Populate() {
        //This method should be called once, and should be in a different class
        ControlDefaults<TextBox>.Action = c => c.Clear();
    }
