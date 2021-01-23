    public ActionResult Index(int? id)
    {
       if(!id.HasValue())
       {
         throw new HttpException(404, "Are you sure you're in the right place?");
       }
    }
