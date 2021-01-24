    public class Foo
    {
        private bool _firstCall = true;
        public object DoSomething() {
            if(_firstCall) {
                _firstCall = false;
                // first call logic
            } else {
                // second call logic
            }
        }
    }
