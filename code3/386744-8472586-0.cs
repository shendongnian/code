    var listInfo = (from infoMember in context.Members
                    where infoMember.TeamID  == TeamID 
                    group infoMember by new
                    { infoMember.TeamID, infoMember.MemberIDCount } into newInfoMemeber
                    select new ClassName
                    {
                       TeamID = newInfo.Key.TeamID,
                       MemberIDCount = newInfo.Key.MemberIDCOunt,
                       Count = newInfo.Count(),
                       TotalCount = (from infoMemeber2 in context.Members
                                     where infoMemeber2.TeamID== TeamID
                                     select infoResult2).Count()
                    }).AsEnumerable();
