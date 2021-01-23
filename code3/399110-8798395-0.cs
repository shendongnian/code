    private bool Ok2Delete(int ri) // ri is the record index to be deleted
    {
        if (Session["ri"] == null ||
           (!((ri == ((int)Session["ri"])) &&
           (DateTime.Now.Subtract((DateTime)Session["ri_time_stamp"]).TotalSeconds < 2))))
        {
           Session["ri"] = ri;
           Session["ri_time_stamp"] = DateTime.Now;
           return true;
        }
        return false;
    }
