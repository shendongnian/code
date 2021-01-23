    declare a collection of say string type,
    List<string> objList = new List<string>();
    
    foreach(GridViewRow row in gridViewId)
    {
        CheckBox chk = row.FindControl("CheckBoxId") as CheckBox;
        if(chk.IsChecked)
        {
         objList.Add(row["id"].Text);
        }
    }
    save this list in session,
    Session["checkedList"] = objList;
    
    when you want to retireve,use,
    objList = List<string>(Session["checkedList"]);
