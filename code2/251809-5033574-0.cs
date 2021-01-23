    List<string> LabeIDList = new List<string>();
    
    override SaveViewState(..)
    {
        if (LabelIDList.Count>0) {
          ViewState["LabelDIList"]=LabelIDList;
        }
        base.SaveViewState(..)
    }
    override LoadViewState()
    {
        base.LoadViewState();
        if (ViewState["LabelIDList"]!=null) {
            LabelIDList = (List<string>)ViewState["LabelIDList"];
        }
    }
    override void OnLoad(..) 
    {
        foreach (string id in LabelIDList)
        {
            // Make a function essentially like your code in createTaskLabel,
            // you can use it there too
            RecreateControl(id);
        }
    }
    private void createTaskLabel(Guid GoalID, string Goal)
    { 
        ...
        // save the ID you just created
        LabelIDList.Add(taskLabel.ID);
    }
