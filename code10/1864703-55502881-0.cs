public Detail GetDetail()
        {
            Detail detail = (Detail)Session["Detail"];
            if (detail == null)
            {
                detail = new Detail();
                Session["Detail"] = detail;
           
            }
            else {
                Session.Abandon();
            }
        
            return detail;
        }
    }
}
However, how would it be better to resolve such a decision, avoiding the session?
