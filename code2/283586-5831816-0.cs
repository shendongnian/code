    protected void SenMail(object prms)
    {
        int id = int.Parse(prms.ToString());
        //mail sending proces
    }
    //starting SendMail method asynchronous
    Thread trd = new Thread(SenMail);
    trd.Start(idValue);
