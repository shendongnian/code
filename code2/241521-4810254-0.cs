    public partial class ClassThatUsesParallelProcessing
    {
        public event ProcessingStatusEvent StatusEvent;
    
        public ClassThatUsesParallelProcessing()
        { }
    
        private void doSomethingInParallel()
        {
            try
            {
                int counter = 0;
                int total = listOfItems.Count;
    
                Parallel.ForEach(listOfItems, (instanceFromList, state) =>
                {
                    // do your work here ...
    
                    // determine your progress and fire event back to anyone who cares ...
                    int count = Interlocked.Increment( ref counter );
    
                    int percentageComplete = (int)((float)count / (float)total * 100);
                    OnStatusEvent(new StatusEventArgs(State.UPDATE_PROGRESS, percentageComplete));
                }
            }
            catch (Exception ex)
            {
    
            }
        }
    }
