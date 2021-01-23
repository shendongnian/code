    public void SomeMethod()
    {
        AllYourBase ayb = new AllYourBase();
        IBase1 b1 = ayb
        double p1 = b1.Percentage;
   
        IBase2 b2 = ayb;
        double p2 = b2.Percentage;
    }
