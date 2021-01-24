      // Sample data.
      DataTable UserCount1 = new DataTable();
      DataTable UserCount2 = new DataTable();
      UserCount1.Columns.AddRange(new DataColumn[] { new DataColumn("LoginId"), new DataColumn("LoginName"), new DataColumn("SCount") });
      UserCount2.Columns.AddRange(new DataColumn[] { new DataColumn("LoginId"), new DataColumn("LoginName"), new DataColumn("ECount") });
      UserCount1.Rows.Add(1, "Mohit", 20);
      UserCount1.Rows.Add(3, "Riya", 25);
      UserCount2.Rows.Add(2, "Smita", 31);
      UserCount2.Rows.Add(3, "Riya", 13);
      // Here we create lists of our users.
      List<User1> users1 = new List<User1>();
      List<User2> users2 = new List<User2>();
      foreach (DataRow row in UserCount1.Rows)
        users1.Add(new User1() { LoginId = int.Parse(row["LoginId"].ToString()), LoginName = (string)row["LoginName"], SCount = int.Parse(row["SCount"].ToString()) });
      foreach (DataRow row in UserCount2.Rows)
        users2.Add(new User2() { LoginId = int.Parse(row["LoginId"].ToString()), LoginName = (string)row["LoginName"], ECount = int.Parse(row["ECount"].ToString()) });
      // Full outer join: first we join, then add entries, that were not included.
      var result = users1.Join(users2, u1 => u1.LoginId, u2 => u2.LoginId, (u1, u2) => new { LoginId = u1.LoginId, LoginName = u1.LoginName, SCount = u1.SCount, ECount = u2.ECount, Total = u1.SCount + u2.ECount }).ToList();
      result.AddRange(users1.Where(u1 => !result.Select(u => u.LoginId).Contains(u1.LoginId)).Select(u1 => new { LoginId = u1.LoginId, LoginName = u1.LoginName, SCount = u1.SCount, ECount = 0, Total = u1.SCount }));
      result.AddRange(users2.Where(u2 => !result.Select(u => u.LoginId).Contains(u2.LoginId)).Select(u2 => new { LoginId = u2.LoginId, LoginName = u2.LoginName, SCount = 0, ECount = u2.ECount, Total = u2.ECount }));
