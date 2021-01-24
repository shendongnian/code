    public PartialViewResult BtnNext(FormCollection Form)
    {
        Int32? Count = Convert.ToInt32(Form["Count"]??0);
        List<Queue> model = db.Queues.OrderBy(x => x.QueueNumber).ToList();
        model.ElementAt(count); //   [NotMapped]  public Int32? count { get; set; } add in model class
        model.count=count+1;
        return PartialView("_queuenumber", model);
    } 
