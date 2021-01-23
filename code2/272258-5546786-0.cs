    private int numHighAttacksHit;
    public int NumHighAttacksHit
    {
                get { return numHighAttacksHit - handicapHighAttacks; }
                set { numHighAttacksHit = value; }
    }
