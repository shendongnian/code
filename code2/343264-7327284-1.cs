    public class MyTimer {
        private readonly Action _fireOnTimer;
    
        public MyTimer(Action fireOnTimer, TimeSpan interval, ...) {
            if (fireOnTimer == null) {
                throw new ArgumentNullException("fireOnTimer");
            }
            _fireOnTimer = fireOnTimer;
        }
        private void Fire() {
            _fireOnTimer();
        }
        ...
    }
