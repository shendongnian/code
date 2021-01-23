    public void get_json<t>()
    {
        t[] all_tag = ActiveRecordBase<t>.FindAll();
        //Other stuff that needs to use the t type.
    }
