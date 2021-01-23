    public class Counters {
        public event EventHandler SomeNameChanged;
        private int someName;
        public int SomeName {
            get { return someName; }
            set {
                if(someName != value) {
                    someName = value;
                    var handler = SomeNameChanged;
                    if(handler != null) handler(this, EventArgs.Empty);
                }
            }
        }
    }
