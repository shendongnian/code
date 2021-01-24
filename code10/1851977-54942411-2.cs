    public ActionResult Detail(Guid? id)
    {
        //Model initialized
        SuperModel model =  GetTheModel();
        
        //Then there were 2 foreach loops throu my einumerables
        model.memberList1.ToList().Foreach((item) => 
        { 
            //Do Things
        });
        model.memberList2.ToList().Foreach((item) => 
        { 
            //Do Things
        });
    }
