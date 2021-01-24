    public class Example
    {
        private void MethodA()
        {
            //logic from methodA
        }
        private void MethodB()
        {
            //logic from methodB
        }
        private void MethodC()
        {
            //logic from methodC
        }
        public void MethodA()
        {
            MethodB();
            MethodA();
            MethodC();
        }
    }
