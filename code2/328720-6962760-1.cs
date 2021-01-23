    DateTime dt = File.GetLastWriteTime(@"c:\sql.exe");
    // If the file does not exist, GetLastWriteTime returns 12:00 midnight,
    // January 1, 1601 A.D. (C.E.) Coordinated Universal Time (UTC), adjusted
    // to local time.
    if (dt == new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc))
    {
       lblSqlC.Text = "Not Found";
    }
    else
    {
       lblSqlC.Text = dt.ToShortDateString();
    }
