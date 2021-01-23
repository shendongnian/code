    public static int GenerateRandomValueDefault(int irRandValRange)//default min val 1
    {
        return GenerateRandomValueMin(irRandValRange, 1);
    }
    public static int GenerateRandomValueMin(int irRandValRange, int irMinValue)
    {
        Random rand = GetRandom();
        return rand.GetNext(irMinValue,irRandValRange)
    }
    //This is a global random number generator, it is only used to provide the seed for the local RNG's.
    private static Random GlobalRandom = new Random();
    private static Random GetRandom()
    {
        if (HttpContext.Current.Session["RNG"] == null)
        {
            //This lock is only hit the very first time the users Session state is used, every time after that it should use the cached local copy without taking the lock.
            lock(GlobalRandom)
            {
                //We use the Global RNG for seed instead of the default because it uses time to seed by default, and if two people get a new Random() within the same time-slice they will have the same seed. This prevents that from happening.
                HttpContext.Current.Session["RNG"] = new Random(GlobalRandom.Next());
            }
        }
        //Return the cached/new RNG.
        return (Random)HttpContext.Current.Session["RNG"];
    }
