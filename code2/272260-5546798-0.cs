    private int numHighAttacksHit;
    public int NumHighAttacksHit   // <-- note the pascal case
        {
            get { return numHighAttacksHit - handicapHighAttacks; }
            set { numHighAttacksHit = value; }
        }
    this.NumHighAttacksHit = 0;
