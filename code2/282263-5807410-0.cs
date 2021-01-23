    public class Thing
    {
        private static volatile bool _tooLate = false;
        private static List<Thing> _theWorld; // contains everything
        private static readonly object _sync = new object();
    
        public Thing(){/*...*/}
    
        // a static method to process the signal
        public static void ProcessSignal(Signal signal)
        {
            // make sure you're not late to the party
            if(signal == signal.DestroyTheWorld && !_tooLate)
            {
                // You won't destroy the world yet... but you'll give it a shot!
                BringAboutTheDestruction();
            }
        }
    
        // a static method to bring about the destruction of the world! MUAHAHAHAHA
        public static void BringAboutTheDestruction()
        {
            // you might not be late for the party, 
            // but you still have to get past the doorman
            lock(_sync)
            {
                // you finally got in, but you might get kicked out!
                if(!_tooLate)
                {
                    // Apocalypse now!!! There is no turning back
                    foreach(Thing t in _theWorld)
                    {
                        t.Destroy();
                    }
                    _theWorld.Clear();
                }
                _tooLate = true;
            }
        }
    }
