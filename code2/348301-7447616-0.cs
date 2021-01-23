    class Flarg
    {
        private readonly Action speak;
    
        public Action Speak
        {
            get
            {
                return this.speak;
            }
        }
    
        public Flarg(Action<Flarg> speak)
        {
            this.speak = () => speak(this);
        }
    }
    class MuteFlarg : Flarg
    {
        public MuteFlarg() : base(x => ((MuteFlarg)x).GiveDumbLook())
        {
        }
    
        private void GiveDumbLook()
        {
        }
    }
