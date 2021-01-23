    public void add(long a)
    {
        Total += a;
    }
    public void display(Object a)// <- boxing is performed here
    {
        Total += (long) a;// <- unboxing is performed here
    }
