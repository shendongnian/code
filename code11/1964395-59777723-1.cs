    private int GegetenKikkers;
    public Ooievaar(string naam, string geslacht, int leeftijd, int gegetenKikkers) : base(naam, geslacht, leeftijd)
    {
        GegetenKikkers = gegetenKikkers;
    }
    public string EetKikker(List<Kikker> kikker, int rndNumber)
    {
        //get the right kikker
        Kikker getKikker = kikker.ElementAt(rndNumber);
        //return a string
        return "Hello my name is " + getKikker.Naamdier + " and I am dead.";
    }
