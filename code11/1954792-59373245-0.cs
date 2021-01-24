    var queryResults = ourdbset.DeleteAllRequests
        .Where(a => a.CustomerID == customerid
            && !a.Approved
            && allsuperadminusers.Contains(a.RequestedBy.ToLower().Trim())
        .ToList();
     var count = queryResults.Where(accountCI.ATTRIBUTE_1501.ToLower().Equals("inactive").Count();
     
     var areEqual = count == allsuperadminusers.Count();
     return areEqual;
 
