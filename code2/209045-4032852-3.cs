    if(Session["myDinamicButtons"] == null){
        List<Button> myDinamicButtonsList = new List<Button>();
        Session["myDinamicButtons"] = myDinamicButtonsList;
    }
    
    foreach(Button btn in Session["myDinamicButtons"] as List<Button>){
        form1.Controls.Add(btn));
    }
