    public class SomeClass
    {
        private static bool IsInizialized = false;
        public SomeClass()
        {
            if (!IsInizialized)
            {
                // static constuctor thread safe but this doesn't
                //
                lock (this)
                {
                    if (!IsInizialized)
                    {
                        IsInizialized = true;
                        // all what static constructor does
                    }
                }
            }
        }
    }
