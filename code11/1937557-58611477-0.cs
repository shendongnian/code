    public List<MemberDTO> getMembers(int planID)
    {
        using (var dbContext = new CompanyHHCEntities())
        {
            var membersList = 
                dbContext.PQIP_Member
                    .Where(member => member.PlanID == planID && (member.TeamAssigned ?? false))
                    .GroupBy(member=>member.EMR_ID) // create groups of members where member has same EMR_ID
                    .SelectMany(grp=>grp.OrderByDesc(member=>member.ID).Take(1)) // from each group, select member with highest ID
                    .Select(member => new MemberDTO()
                               {
                                   MemberID = member.ID,
                                   EMR_ID = member.EMR_ID ?? 0,
                                   FullName = member.FirstName + " " + member.LastName,
                                   Phone1 = member.HomePhone,
                                   Phone2 = member.Phone2,
                                   Street1 = member.Street1,
                                   Street2 = member.Street2,
                                   City = member.City,
                                   State = member.State,
                                   Zip = member.Zip
                               })
                    .OrderBy(a => a.FullName)
                    .ToList();
            return membersList;
        }
    }
