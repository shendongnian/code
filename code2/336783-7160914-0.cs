    public abstract class Animal
        {
    
            static int _fleas;
    
            public int Fleas
            {
                get { return _fleas; }
                set { _fleas = value; }
            }
    
            public abstract string GetSound();
    
        }
