    using System;
    public abstract class C
    {
        public abstract void WithAction(Action a);
        private bool creating = true;
        public void M()
        {
            WithAction(() => creating = false);
            while (creating) {}
        }
    }
