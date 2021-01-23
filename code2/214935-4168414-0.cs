    public class Foo {
        private bool frozen = false;
        private string something;
        public string Something {
            get { return something; }
            set {
                if (frozen)
                    throw new InvalidOperationException("Object is frozen.");
                // validate value
                something = value;
            }
        }
        public void Freeze() {
            frozen = true;
        }
    }
