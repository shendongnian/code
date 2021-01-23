    public abstract class AbstractBase {
        // "the rest"
        public void StartListening() {
            Timer timer = new Timer(CheckForChanges, null, 0, 1000);            
        }
        protected abstract void CheckForChanges();
    }
    public class A : AbstractBase {
        public delegate void AHandler(string param1, string param2);
        public void AcceptHandler(string param3, AHandler handler);
        public void InvokeHandler(string forParam1, string forParam2);
        protected override void CheckForChanges() {
            //Do stuff for this version of the class
        }
    }
    public class B : AbstractBase {
        public delegate void BHandler(int param1);
        public void AcceptHandler(int param2, int param3, int param4, BHandler handler);
        public void InvokeHandler(int forParam1);
        protected override void CheckForChanges() {
            //Do stuff for this version of the class
        }
    }
