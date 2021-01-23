    class SampleOperation : ISteppedOperation
    {
        private int maxSteps = 100;
        //// The basic way of doing work that I want to monitor
        //public void DoSteppedWork()
        //{
        //    for (int currentStep = 0; currentStep < maxSteps; currentStep++)
        //    {
        //        System.Threading.Thread.Sleep(100);
        //    }
        //}
        // The same thing broken down to implement ISteppedOperation
        private int currentStep = 0; // before the first step
        public bool MoveNext()
        {
            if (currentStep == maxSteps)
                return false;
            else
            {
                currentStep++;
                return true;
            }
        }
        public void ProcessCurrent()
        {
            System.Threading.Thread.Sleep(100);
        }
        public int StepCount
        {
            get { return maxSteps; }
        }
        public int CurrentStep
        {
            get { return currentStep; }
        }
        // Re-implement the original method so it can still be run synchronously
        public void DoSteppedWork()
        {
            while (MoveNext())
                ProcessCurrent();
        }
    }
