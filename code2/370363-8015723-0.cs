    from att in context.Attendees
                              join webUsers in context.WebUsers
    on att.web_user_id equals webUsers.id
                              join invoice in context.Invoice
                              on att.InvoiceID equals invoice.ID                          
                              where invoice.SeminarID == seminarId                                       
                              select new
                              {
                                  webUsers.FirstName,
                                  att.InvoiceID                                                       
                              };
