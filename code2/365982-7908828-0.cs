    public static int GenerateRandomValueDefault(int irRandValRange)//default min val 1
    {
        GenerateRandomValueMin(irRandValRange, 1);
    }
    public static int GenerateRandomValueMin(int irRandValRange, int irMinValue)
    {
        Random rand = GetRandom();
        return rand.GetNext(1,irRandValRange)
    }
    private static Random GlobalRandom = new Random();
    private static Random GetRandom()
    {
        if (HttpContext.Current.Session["RNG"] == null)
        {
            lock(GlobalRandom)
            {
                HttpContext.Current.Session["RNG"] = new Random(GlobalRandom.Next());
            }
        }
        return (Random)HttpContext.Current.Session["RNG"];
    }
