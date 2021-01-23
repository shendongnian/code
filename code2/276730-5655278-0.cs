    DateTime today = DateTime.Today; // read once, avoid "odd" errors once in a blue moon
    DateTime yesterday = today.AddDays(-1);
    YesterdaysRegistrations = db.tblForumAuthors.Where(
        c => c.Join_date >= yesterday
          && c.Join_date < today).Count();
