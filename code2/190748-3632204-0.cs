        public void MyBigBackgroundTask()
        {
            Action[] tasks = new Action[] { Alpha, Bravo, Charlie, Delta };
            int workStepSize = 0;
            while (!_shouldStop)
            {
                tasks[workStepSize++]();
                workStepSize %= tasks.Length;
            };
        }
