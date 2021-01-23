    class Kebab
    {
        public static int NumberOfCallsToIsValid = 0;
    
        public bool IsValid()
        {
            NumberOfCallsToIsValid++;
            return false;
        }
    }
    
    ...
    var kebabs = new Kebab[] { new Kebab(), new Kebab() };
    kebabs.Any(kebab => !kebab.IsValid());
    
    Debug.Assert(Kebab.NumberOfCallsToIsValid == 1);
