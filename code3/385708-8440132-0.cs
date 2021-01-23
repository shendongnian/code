    interface ILoopingIterator
    {
        void Next();
        void Previous();
    }
    
    interface INonLoopingIterator
    {
        void Next();
    }
    
    class PlaysItBothWays : ILoopingIterator, INonLoopingIterator
    {
        void ILoopingIterator.Next()
        {
             this.NextCore();
        }
    
        void ILoopingIterator.Previous()
        {
             // since this code will never be shared anyway, put it here
        }
    
        void INonLoopingIterator.Next()
        {
             this.NextCore();
        }
    
        private void NextCore()
        {
            // do stuff here; this method only exists so that code can be shared
        }
    }
