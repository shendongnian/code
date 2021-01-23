    var data = (from v in abc.visits 
                join m in abc.members on v.member_Id equals m.member_Id
                select new
                {
                    MemberID = v.member_id,
                    VisiteDate = v.visit_date,
                    FirstName = m.member_FirstName,
                    LastName = m.member_LastName
                }).ToList();    
    var memberl = from d in data    
                  where Convert.ToDateTime(d.VisitDate) >= startdate && Convert.ToDateTime(d.VisitDate) <= enddate           
                  group d by new { d.FirstName, d.LastName, d.MemberID } into g           
                  orderby g.Count()           
                  select new           
                  {           
                      numVisits = g.Count(),           
                      firstname = g.Key.FirstName,           
                      lastname = g.Key.LastName           
                  }; 
