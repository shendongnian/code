    private Bll() { }
    
    public static Bll Create()
    {
        IBll bll = new Bll();
        bll.Dal = new Dal();
        return bll;
    }
