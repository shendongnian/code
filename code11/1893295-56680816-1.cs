    interface ITimerClient
    {
        void Timeout();
    }
    class Door : ITimerClient
    {
        public virtual void Timeout()
        {
            //No operation; this isn't a timed door
        }
        //etc.
    }
    class TimedDoor : Door
    {
        public override void Timeout()
        {
            this.Unlock();  //Override default behavior because this type of door is timed
            base.Timeout();  //Optional, sometimes recommended
        }
        //etc.
    }
