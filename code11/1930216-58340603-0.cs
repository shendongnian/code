    [HttpPost]
    public JsonResult UpdateTicketFromDetails()
    {
        var ticketStatusInput = Request.Form["ticketStatusInput"];
    
        var ticketStatusInput = Request.Form["ticketStatusInput"];
        var oExcludeItem = new string[] { "ABT", "CDO", "ESU" }; // You can use string array also   
        if (!string.IsNullOrEmpty(ticketStatusInput))
        {
            if (oExcludeItem.Contains(ticketStatusInput))
            {
                return Json(new TicketResult
                {
                    IsValid = false,
                    Error = "Please select only enable option";
                 });
            }
        }
        else
        {
            return Json(new TicketResult
            {
                IsValid = false,
                Error = "Please select valid data";
           });
        }
        var lstDisableOption = new List<string>(); // You can also use with List object
        lstDisableOption.Add("ABT");
                lstDisableOption.Add("CDO");
                lstDisableOption.Add("ESU");
                if (!string.IsNullOrEmpty(ticketStatusInput))
                {
                    if (lstDisableOption.Any(x => x == ticketStatusInput))
                    {
                        return Json(new TicketResult
                        {
                            IsValid = false,
                            Error = "Please select only enable option";
                        });
                     }
                }
                else
                {
                    return Json(new TicketResult
                    {
                        IsValid = false,
                        Error = "Please select valid data";
                     });
                 }
            }
    
        try
        {
            TicketRegisterResult result;
            using (var scope = new TransactionScope())
            {
                // I create a new record variable with all fields
                var record = new TK_DT_RECORDS
                {
                    TK_CT_STATUS_ID = ticketStatusInput,
                };
                // We update the ticket data (this will always be done)
                var model = new TicketRegisterModel();
                // We create the new record in the record table and insert it
                result = model.UpdateTicket;
    
                //If the ticket was not saved, the transaction is finished and we return the error message
                if (!result.Success)
                    return Json(new TicketResult
                    {
                        IsValid = false,
                        Error = "The changes could not be saved, please try again."
                    });
                scope.Complete();
            }
        }
        catch (DbEntityValidationException ex)
        {
            //Failed to try to register data in the database
            foreach (var e in ex.EntityValidationErrors)
                foreach (var validationError in e.ValidationErrors)
                    Console.WriteLine("Property: " + validationError.PropertyName + " Error: " +
                                      validationError.ErrorMessage);
    
            return Json(new TicketResult
            {
                IsValid = false,
                Error = "There was an error creating the ticket, please try again."
            });
        }
        return Json(new TicketResult
        {
            IsValid = true
        });
    }
