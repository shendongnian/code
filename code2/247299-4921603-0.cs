    //This how to add value in session "ID" Is the name of the session and "1" is the value
    Session.Add("ID", 1);
    //How to retrieve the value which is in the Session 
    int ID = Convert.ToInt16(Session["ID"]);
    //write session Value
    Response.Write(ID.ToString());
