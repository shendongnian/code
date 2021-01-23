    public void A_1(object obj)
    {
        ...
        B b = (B)obj;
        b.B_1();
        // or
        ((B)obj).B_1();
    }
