    public class X {
        private X() {}
        protected virtual void Init(){
            MessageBox.Show("I'm X");    
        }
        public static GetX() {
            X ret = new X();
            ret.Init();
            return ret;
        }
    }
    public class Y : X {
        private Y() {}
        protected virtual void Init(){
            MessageBox.Show("I'm Y");    
        }
        public static GetY() {
            Y ret = new Y();
            ret.Init();
            return ret;
        }
    }
