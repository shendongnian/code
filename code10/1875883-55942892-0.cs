    public class ClassWithComplexPrivateMethod
    {
        
        public void DoSomething(int value)
        {
            PrivateMethodThatNeedsItsOwnTests(value);
        }
        private void PrivateMethodThatNeedsItsOwnTests(int value)
        {
            // This method has gotten really complicated!
        }
    }
