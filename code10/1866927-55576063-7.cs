        var result = dbContext.Ministries.SelectMany(ministry.MemberGroups,
          (ministry, memberGroup) => new
          {
               MinistryId = ministry.Id,
               MinistryName = ministry.Name,
               MemberGroupName = memgerGroup.Name,
          });
