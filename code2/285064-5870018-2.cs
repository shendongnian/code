    var myList = new List<TicketInfo>();
    while (myReader.Read())
    {
        myList.Add(new TicketInfo
        {
            TicketCost = Convert.ToDecimal(myReader["TicketCost"]),
            NumTickets = Convert.ToInt32(myReader["NumTickets"])
        });
    }
    grdEvents.DataSource = myList;
    grdEvents.DataBind();
