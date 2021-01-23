    var query = (from mg in db.MembershipGroups
                join m in db.Members.Where(mem => mem.Status == "Active")
                on mg.ID equals m.MembershipGroups into members
                select new
                {
                   MembershipGroup = mg,
                   Members = members
                }).AsEnumerable()
                  .Select(m => new MembershipGroup  
                               {
                                 ID = m.MembershipGroup.ID,
                                 Title = m.MembershipGroup.Title,
                                 Members = m.Members 
                               });
