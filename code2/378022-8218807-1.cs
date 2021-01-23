    class SpeakerSystem
    {
        Speaker[] _speakers = ...;
    
        public void PowerOff()
        {
            foreach(var speaker in _speakers)
               speaker.PowerOff();
        }
    }
