    using (myConnection)
    {
       myConnection.Open();
       DataSet ds = myCommand.ExecuteDataSet();
       //Binds listbox
       grdEvents.DataSource = ds;
       grdEvents.DataBind();                    
    }
    ForEach (DataRow dr in ds.tables[0].rows)
        myList.Add(new TicketInfo{TicketCost = Convert.ToDecimal(myReader["TicketCost"]),NumTickets = Convert.ToInt32(myReader["NumTickets"])  });  
