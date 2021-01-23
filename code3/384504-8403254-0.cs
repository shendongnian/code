    public class CustomControl {
        public Action<string> SetData { get; set; }
        public void Update() {
            // TODO nullity check
            SetData("test");
        }
    }
