    public class X {
        public X() {
            MessageBox.Show("I'm X");
        }
        protected X(int dummy){
        }
    }
    
    public class Y : X {
        public Y() : X(0) { //will call other constructor
            MessageBox.Show("I'm Y");
        }
    }
