    // Convert the boundaries to strings first
    string startDateAsString = startdate.ToString(/* Format option to match the database format */);
    string endDateAsString = enddate.ToString(/* Format option to match the database format */);
    // Query based on string comparison
    var memberl = from v in abc.visits
                  join m in abc.members on v.member_Id equals m.member_Id
                  where v.visit_Date.CompareTo(startDateAsString) >= 0 && 
                        v.visit_Date.CompareTo(endDateAsString) <= 0
                  group m by new { m.member_Firstname, 
                                   m.member_Lastname, m.member_Id } into g
                  orderby g.Count()
                  select new
                  {
                      numVisits = g.Count(),
                      firstname = g.Key.member_Firstname,
                      lastname = g.Key.member_Lastname
                  };
