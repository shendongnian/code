    class MyFancyClass
    {
        Func<string> getObjectString;
        public MyFancyClass(Func<string> getObjectString)
        {
            this.getObjectString = getObjectString;
        }
        private MyOtherThread()
        {
            // ...
            string desc = getObjectString();
            // ...
        }
    }
    // ...
    long value = 34;
    MyFancyClass fancy = new MyFancyClass(() => value.ToString());
    // ...
    value = 88;
    // getObjectString() should now reflect the new value.
    // The variable is captured in the lambdas closure.
