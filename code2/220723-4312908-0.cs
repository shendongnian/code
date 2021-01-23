    //set up the data
    var rows = new []
    {
        new { UserName = "shd.1234", ID = 3, Designation = 1, RoleID = 2 },
        new { UserName = "shd.1234", ID = 3, Designation = 1, RoleID = 5 },
        new { UserName = "shd.1234", ID = 4, Designation = 1, RoleID = 1 },
        new { UserName = "shd.1234", ID = 4, Designation = 1, RoleID = 7 }
    };
    
    //group our results and order the group by the role id
    var temp = rows.OrderBy(row => row.RoleID).GroupBy(row => row.ID).Select(g => new { First = g.First(), Last = g.Last() });
         
    //select the data into the shape that we want
    var query = temp.Select(result => new
    {
        result.First.UserName,
        result.First.ID,
        result.First.Designation,
        result.First.RoleID,
        AdditionalRoleID = result.Last.RoleID
    });
