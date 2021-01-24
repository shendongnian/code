    public class ClassWithComplexPrivateMethod
    {
        public void DoSomething(int value)
        {
            PrivateMethodThatNeedsItsOwnTests(value);
        }
        private string PrivateMethodThatNeedsItsOwnTests(int value)
        {
            // This method has gotten really complicated!
            return value.ToString();
        }
    }
