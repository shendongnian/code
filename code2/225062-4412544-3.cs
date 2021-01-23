    abstract class Bird {
        public abstract bool CanFly { get; }
        public string SayCanFly() {
            if(CanFly) {
                return "Yes, I can!";
            }
            else {
                return "No, I can't!";
            }
        }
    }
    class Penguin : Bird {
        public override bool CanFly {
            get {
                return false;
            }
        }
    }
    class Eagle : Bird {
        public override bool CanFly {
            get {
                return true;
            }
        }
    }
