    public ActionResult Create()
    {
        var myQuestion = new MyQuestion();
        myQuestion.QuestionTypeList = db.QuestionTypes.Select(x => new SelectListItem 
        {
            Text = x.Name, 
            Value = x.Id 
        }).ToList();
        return View(myQuestion);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(MyQuestion mq)
    {
        if (ModelState.IsValid)
        {
            // process data and redirect
        }
        mq.QuestionTypeList = db.QuestionTypes.Select(x => new SelectListItem 
        { 
            Text = x.Name, 
            Value = x.Id, 
            Selected = (x.Id == mq.QuestionType) 
        }).ToList();
        return View(mq);
    }
