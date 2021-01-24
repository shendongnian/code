    public ActionResult Detail(Guid? id)
    {
        //Model initialized
        SuperModel model =  GetTheModel();
        
        //Then there were 2 foreach loops throu my einumerables
        foreach(var item in model.memberList1)
        {
            //Do things
        }
        foreach(var item in model.memberList2)
        {
            //Do things
        }
    }
